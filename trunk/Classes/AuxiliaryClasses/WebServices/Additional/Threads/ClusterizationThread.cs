using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class ClusterizationThread : IThread
    {
        private RequestClusterization InputData = null;

        public override void SetData(object data)
        {
            InputData = (RequestClusterization) data;
        }

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