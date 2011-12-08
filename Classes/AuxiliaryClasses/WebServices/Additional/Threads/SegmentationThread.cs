using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class SegmentationThread : IThread
    {
        public override void SetData(Request data)
        {
            InputData = (RequestSegmentation) data;   
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerSegmentation result = WS.Segmentation((RequestSegmentation)InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}