using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class MarkovChainThread : IThread
    {
        private RequestMarkovChain InputData = null;

        public override void SetData(object data)
        {
            InputData = (RequestMarkovChain) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerMarkovChain result = WS.GenerateMarkovChains(InputData);
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream File = new FileStream(hashvalue + ".csd", FileMode.CreateNew, FileAccess.Write);
            serializer.Serialize(File, result);
            File.Close();
        }
    }
}