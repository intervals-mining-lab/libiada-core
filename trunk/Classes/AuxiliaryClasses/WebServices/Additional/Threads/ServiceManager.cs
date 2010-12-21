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
    /// Класс-менеджер вычислительных потоков. Синглтон.
    ///</summary>
    public class ServiceManager
    {
        private static Hashtable ThreadPool = null;
        private static ServiceManager state = null;
        private FactoryThreads ThreadsFactory = new FactoryThreads();
        private Random RandomGenerator = new Random();

        ///<summary>
        /// Метод, возвращающий ссылку на экземпляр ServiceManager.
        /// Создает новый экземпляр если к объекту раньше не обращались.
        ///</summary>
        ///<returns>Ссылка на экземпляр ServiceManager</returns>
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
        /// Метод запускающий новый поток вычислений. 
        /// Также добавляет нить в пул потоков по хеш коду от времени создания нити.
        ///</summary>
        ///<param name="data">Исходные данные для вычислений</param>
        ///<param name="type">Название сервиса, который надо запустить</param>
        ///<returns>Хеш-код запущенной нити.</returns>
        public string NewCalculation(Request data, WebServiceType type)
        {
            //Вычисляем хеш
            string hash = getMd5Hash(DateTime.Now.ToString("F") + DateTime.Now.Millisecond.ToString() + RandomGenerator.Next(100).ToString());
            //Создаём нить и запускаемеё на вычисление
            IThread Thr = ThreadsFactory.CreateThread(type);
            Thr.SetData(data);
            Thr.SetHash(hash);
            Thread thread = new Thread(Thr.Calculate);
            thread.Start();
            //Добавляем нить в пул
            lock (ThreadPool.SyncRoot)
            {
                ThreadPool.Add(hash, thread);
            }
            return hash;
        }


        /// <summary>
        /// Метод, вычисляющий хэш код для произвольных данных.
        /// </summary>
        /// <param name="input">Исходные данные</param>
        /// <returns>Хеш</returns>
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
        /// Метод позволяющий проверять ход вычислений.
        /// </summary>
        /// <param name="hashvalue">Хеш-код</param>
        /// <param name="type">Тип веб-сервиса</param>
        /// <returns>Стандарный объект-ответ</returns>
        public object Check(string hashvalue, WebServiceType type)
        {
            //Ищем нить в хэш-таблице(пул) нитей
            Thread thread = null;
            lock (ThreadPool.SyncRoot)
            {
                thread = ThreadPool[hashvalue] as Thread;
            }
            //Создаём контейнер-ответ для клиента
            Answer answer = AnswerFactory.CreateAnswer(type);
            if (thread == null)
            {
                Object obj = null;
                lock (ThreadPool.SyncRoot)
                {
                    obj = ThreadPool[hashvalue];
                }
                //если нити с заданным кодом нет в пуле
                if (obj == null)
                {
                    answer.Error = ErrorType.IdError;
                    return answer;
                }
                answer.Error = ErrorType.FullP;
                return answer;
            }
            //если нить есть и вычисления ещё идут
            if (thread.IsAlive)
            {
                answer.Error = ErrorType.Calculating;
                return answer;
            }
            //если вычисления закончены
            Object result = null;
            lock (ThreadPool.SyncRoot)
            {
                try
                {
                    //десериализуем файл с результатами, созданный вычислительной нитью
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
