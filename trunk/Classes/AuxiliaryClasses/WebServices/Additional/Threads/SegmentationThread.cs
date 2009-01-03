using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class SegmentationThread : IThread
    {
        private RequestSegmentation InputData = null;

        public override void SetData(object data)
        {
            InputData = (RequestSegmentation) data;   
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerSegmentation result = WS.Segmentation(InputData);
            BinaryFormatter serializer = new BinaryFormatter();
            FileStream File = new FileStream(hashvalue + ".csd", FileMode.CreateNew, FileAccess.Write);
            serializer.Serialize(File, result);
            File.Close();
        }
    }
}