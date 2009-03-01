using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class PhantomChainThread : IThread
    {
        private RequestPhantomChains InputData = null;

        public override void SetData(object data)
        {
            InputData = (RequestPhantomChains) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerPhantomChains result = WS.PhantomChains(InputData);
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream File = new FileStream(hashvalue + ".csd", FileMode.CreateNew, FileAccess.Write);
            serializer.Serialize(File, result);
            File.Close();
        }
    }
}