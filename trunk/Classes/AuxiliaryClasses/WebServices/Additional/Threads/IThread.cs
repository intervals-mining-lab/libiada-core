using System.Collections;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    /// Универсальный интерфейс вычислительного сервиса.
    ///</summary>
    public abstract class IThread
    {
        protected string hashvalue = null;
        protected Hashtable ResultsTable;
        protected Request InputData = null;

        ///<summary>
        /// Устанавливает исходные данные для вычислений.
        ///</summary>
        ///<param name="data">Исходные данные</param>
        public abstract void SetData(Request data);

        ///<summary>
        /// Метод в котором устанавливается хеш-таблица 
        /// в которую будет складываться результат вычислений
        ///</summary>
        ///<param name="resultContainer">Хеш-таблица</param>
        public void SetResultContainer(Hashtable resultContainer)
        {
            ResultsTable = resultContainer;
        }

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
