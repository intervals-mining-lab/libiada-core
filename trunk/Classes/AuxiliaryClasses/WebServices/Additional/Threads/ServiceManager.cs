using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    /// �����-�������� �������������� �������. ��������.
    ///</summary>
    public class ServiceManager
    {
        private static Hashtable ThreadPool = null;
        private static ServiceManager state = null;
        private FactoryThreads ThreadsFactory = new FactoryThreads();
        private Random RandomGenerator = new Random();

        ///<summary>
        /// �����, ������������ ������ �� ��������� ServiceManager.
        /// ������� ����� ��������� ���� � ������� ������ �� ����������.
        ///</summary>
        ///<returns>������ �� ��������� ServiceManager</returns>
        public static ServiceManager Create()
        {
            if (state == null)
            {
                state = new ServiceManager();

            }

            return state;
        }

        protected ServiceManager()
        {
            ThreadPool = new Hashtable();
        }

        ///<summary>
        /// ����� ����������� ����� ����� ����������. 
        /// ����� ��������� ���� � ��� ������� �� ��� ���� �� ������� �������� ����.
        ///</summary>
        ///<param name="data">�������� ������ ��� ����������</param>
        ///<param name="type">�������� �������, ������� ���� ���������</param>
        ///<returns>���-��� ���������� ����.</returns>
        public string NewCalculation(Request data, WebServiceType type)
        {
            //��������� ���
            string hash = getMd5Hash(DateTime.Now.ToString("F") + DateTime.Now.Millisecond.ToString() + RandomGenerator.Next(100).ToString());
            //������ ���� � ���������� �� ����������
            IThread Thr = ThreadsFactory.CreateThread(type);
            Thr.SetData(data);
            Thr.SetHash(hash);
            Thread thread = new Thread(Thr.Calculate);
            thread.Start();
            //��������� ���� � ���
            lock (ThreadPool.SyncRoot)
            {
                ThreadPool.Add(hash, thread);
            }
            return hash;
        }


        /// <summary>
        /// �����, ����������� ��� ��� ��� ������������ ������.
        /// </summary>
        /// <param name="input">�������� ������</param>
        /// <returns>���</returns>
        private string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// ����� ����������� ��������� ��� ����������.
        /// </summary>
        /// <param name="hashvalue">���-���</param>
        /// <param name="type">��� ���-�������</param>
        /// <returns>���������� ������-�����</returns>
        public object Check(string hashvalue, WebServiceType type)
        {
            //���� ���� � ���-�������(���) �����
            Thread thread = null;
            lock (ThreadPool.SyncRoot)
            {
                thread = ThreadPool[hashvalue] as Thread;
            }
            //������ ���������-����� ��� �������
            Answer answer = AnswerFactory.CreateAnswer(type);
            if (thread == null)
            {
                Object obj = null;
                lock (ThreadPool.SyncRoot)
                {
                    obj = ThreadPool[hashvalue];
                }
                //���� ���� � �������� ����� ��� � ����
                if (obj == null)
                {
                    answer.Error = ErrorType.IdError;
                    return answer;
                }
                answer.Error = ErrorType.FullP;
                return answer;
            }
            //���� ���� ���� � ���������� ��� ����
            if (thread.IsAlive)
            {
                answer.Error = ErrorType.Calculating;
                return answer;
            }
            //���� ���������� ���������
            Object result = null;
            lock (ThreadPool.SyncRoot)
            {
                try
                {
                    //������������� ���� � ������������, ��������� �������������� �����
                    BinaryFormatter deserializer = new BinaryFormatter();
                    FileStream FileS = new FileStream(hashvalue + ".csd", FileMode.Open, FileAccess.Read);
                    result = deserializer.Deserialize(FileS);
                    FileS.Close();
                }
                catch (Exception e)
                {
                    
                    answer.Error = ErrorType.FileError;
                    return answer;
                }               

                string dir = Directory.GetCurrentDirectory();
                string fileName = hashvalue + ".csd";
                string resFile = System.IO.Path.Combine(dir, fileName);
                System.IO.File.Delete(resFile);

                ThreadPool.Remove(hashvalue);
            }
            return result;
        }
    }
}
