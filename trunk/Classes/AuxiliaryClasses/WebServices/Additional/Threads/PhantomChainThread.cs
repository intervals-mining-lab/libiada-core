using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    /// <summary>
    /// Нить соответсвующая сервису фантомных цепей
    /// </summary>
    internal class PhantomChainThread : IThread
    {
        private RequestPhantomChains InputData = null;

        /// <summary>
        /// Метод устанавливает исходные данные для вычислений.
        /// Требуемый тип данных  <see cref="RequestPhantomChains"/>.
        /// </summary>
        /// <param name="data">Исходные данные</param>
        public override void SetData(Request data)
        {
            InputData = (RequestPhantomChains) data;
        }

        /// <summary>
        /// Метод запускающий генерацию фантомных цепочек 
        /// и сохраняющий результаты в файл вида "хеш-код.csd".
        /// </summary>
        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerPhantomChains result = WS.PhantomChains(InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}