using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class AlphabetThread : IThread
    {
        private RequestFiles InputData = null;

        public override void SetData(object data)
        {
           InputData = (RequestFiles) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerObjects result = WS.CreateAlphabet(InputData);
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream File = new FileStream(hashvalue + ".csd", FileMode.CreateNew, FileAccess.Write);
            serializer.Serialize(File,result);
            File.Close();
        }
    }
}