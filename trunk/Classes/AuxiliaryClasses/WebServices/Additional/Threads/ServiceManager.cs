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
    ///</summary>
    public class ServiceManager
    {
        private static Hashtable  ThreadPool= null; 
        private static ServiceManager state = null;
        private FactoryThreads ThreadsFactory = new FactoryThreads();
        //private Mutex mutex = new Mutex();
        private Random RandomGenerator = new Random();

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static ServiceManager Create()
        {
            if (state == null)
            {
                ServiceManager SM = new ServiceManager();
                state = SM;
               
            }

            return state;
        }

        protected ServiceManager()
        {
            ThreadPool = new Hashtable();
        }

        ///<summary>
        ///</summary>
        ///<param name="data"></param>
        ///<param name="type"></param>
        ///<returns></returns>
        public string NewCalculation(object data,WebServiceType type)
        {
            string hash = getMd5Hash(DateTime.Now.ToString("F") + DateTime.Now.Millisecond.ToString() + RandomGenerator.Next(100).ToString());
            IThread Thr = ThreadsFactory.CreateThread(type);
            Thr.SetData(data);
            Thr.SetHash(hash);
            Thread thread = new Thread(Thr.Calculate);
            thread.Start();
            lock (ThreadPool.SyncRoot)
            {
                ThreadPool.Add(hash, thread);
            }
            return hash;
        }

        static string getMd5Hash(string input)
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

        ///<summary>
        ///</summary>
        ///<param name="hashvalue"></param>
        ///<returns></returns>
        ///<param name="type"></param>
        public object Check(string hashvalue,WebServiceType type)
        {
            Thread thread = null;
            lock (ThreadPool.SyncRoot)
            {
                thread = ThreadPool[hashvalue] as Thread;
            }
            if(thread == null)
            {
                Object obj = null;
                lock (ThreadPool.SyncRoot)
                {
                    obj = ThreadPool[hashvalue];
                }
                if (obj == null)
                {
                    switch (type)
                    {
                        case WebServiceType.Alphabet:
                            AnswerObjects answer1 = new AnswerObjects();
                            answer1.Error = ErrorType.IdError;
                            return answer1;

                        case WebServiceType.Calculate:
                            AnswerChain answer2 = new AnswerChain();
                            answer2.Error = ErrorType.IdError;
                            return answer2;

                        case WebServiceType.MarkovChain:
                            AnswerMarkovChain answer3 = new AnswerMarkovChain();
                            answer3.Error = ErrorType.IdError;
                            return answer3;

                        case WebServiceType.Segmentation:
                            AnswerSegmentation answer4 = new AnswerSegmentation();
                            answer4.Error = ErrorType.IdError;
                            return answer4;

                        case WebServiceType.PhantomChain:
                            AnswerPhantomChains answer5 = new AnswerPhantomChains();
                            answer5.Error = ErrorType.IdError;
                            return answer5;

                        case WebServiceType.Clusterization:
                            AnswerClusterization answer6 = new AnswerClusterization();
                            answer6.Error = ErrorType.IdError;
                            return answer6;

                        default:
                            throw new Exception("Wrong action type");
                    }
                }
                else
                {
                    switch (type)
                    {
                        case WebServiceType.Alphabet:
                            AnswerObjects answer1 = new AnswerObjects();
                            answer1.Error = ErrorType.FullP;
                            return answer1;

                        case WebServiceType.Calculate:
                            AnswerChain answer2 = new AnswerChain();
                            answer2.Error = ErrorType.FullP;
                            return answer2;

                        case WebServiceType.MarkovChain:
                            AnswerMarkovChain answer3 = new AnswerMarkovChain();
                            answer3.Error = ErrorType.FullP;
                            return answer3;

                        case WebServiceType.Segmentation:
                            AnswerSegmentation answer4 = new AnswerSegmentation();
                            answer4.Error = ErrorType.FullP;
                            return answer4;

                        case WebServiceType.PhantomChain:
                            AnswerPhantomChains answer5 = new AnswerPhantomChains();
                            answer5.Error = ErrorType.FullP;
                            return answer5;

                        case WebServiceType.Clusterization:
                            AnswerClusterization answer6 = new AnswerClusterization();
                            answer6.Error = ErrorType.FullP;
                            return answer6;

                        default:
                            throw new Exception("Wrong action type");
                    }
                }
            }
            else if(thread.IsAlive)
            {
                switch(type)
                {
                    case WebServiceType.Alphabet:
                        AnswerObjects answer1 = new AnswerObjects();
                        answer1.Error = ErrorType.Calculating;
                        return answer1;

                    case WebServiceType.Calculate:
                        AnswerChain answer2 = new AnswerChain();
                        answer2.Error = ErrorType.Calculating;
                        return answer2;

                    case WebServiceType.MarkovChain:
                        AnswerMarkovChain answer3 = new AnswerMarkovChain();
                        answer3.Error = ErrorType.Calculating;
                        return answer3;

                    case WebServiceType.Segmentation:
                        AnswerSegmentation answer4 = new AnswerSegmentation();
                        answer4.Error = ErrorType.Calculating;
                        return answer4;

                    case WebServiceType.PhantomChain:
                        AnswerPhantomChains answer5 = new AnswerPhantomChains();
                        answer5.Error = ErrorType.Calculating;
                        return answer5;

                    case WebServiceType.Clusterization:
                        AnswerClusterization answer6 = new AnswerClusterization();
                        answer6.Error = ErrorType.Calculating;
                        return answer6;

                    default:
                        throw new Exception("Wrong action type");


                }

            }
            else
            {
                Object result = null;
                /*Monitor.Enter(this);
                lock (this)
                {*/
                lock(ThreadPool.SyncRoot)
                {
                    //mutex.WaitOne();
                    BinaryFormatter deserializer = new BinaryFormatter();
                    FileStream FileS = new FileStream(hashvalue + ".csd", FileMode.Open, FileAccess.Read);
                    result = deserializer.Deserialize(FileS);
                    FileS.Close();
                    System.IO.File.Delete(hashvalue + ".csd");
                    ThreadPool.Remove(hashvalue);
                    //mutex.ReleaseMutex();
                }
                /*}
                Monitor.Exit(this);*/
                return result;
            }

        }
    }
}