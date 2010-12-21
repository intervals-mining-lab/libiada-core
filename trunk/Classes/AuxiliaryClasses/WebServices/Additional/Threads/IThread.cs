using System;
using System.Collections.Generic;
using System.Text;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    /// Универсальный интерфейс вычислительного сервиса.
    ///</summary>
    public abstract class IThread
    {
        protected string hashvalue = null;

        ///<summary>
        /// Устанавливает исходные данные для вычислений.
        ///</summary>
        ///<param name="data">Исходные данные</param>
        public abstract void SetData(Request data);

        ///<summary>
        /// Устанавливает значение хеш-кода вычислительного потока.
        ///</summary>
        ///<param name="hash">Хеш</param>
        public  void SetHash(string hash)
        {
            hashvalue = hash;
        }

        ///<summary>
        /// Метод запускающий конкретный вычислительный сервис.
        ///</summary>
        public abstract void Calculate();
    }
}
