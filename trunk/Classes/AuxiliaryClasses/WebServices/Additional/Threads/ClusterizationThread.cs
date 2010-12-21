using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    /// <summary>
    /// Нить соответсвующая сервису кластеризации
    /// </summary>
    internal class ClusterizationThread : IThread
    {
        private RequestClusterization InputData = null;

        /// <summary>
        /// Метод устанавливает исходные данные для вычислений.
        /// Требуемый тип данных  <see cref="RequestClusterization"/>.
        /// </summary>
        /// <param name="data">Исходные данные</param>
        public override void SetData(Request data)
        {
            InputData = (RequestClusterization) data;
        }


        /// <summary>
        /// Метод запускающий кластеризацию объектов 
        /// и сохраняющий результаты в файл вида "хеш-код.csd".
        /// </summary>
        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerClusterization result = WS.KRAB(InputData);
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream File = new FileStream(hashvalue + ".csd", FileMode.CreateNew, FileAccess.Write);
            serializer.Serialize(File, result);
            File.Close();
        }
    }
}