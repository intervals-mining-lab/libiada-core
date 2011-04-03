using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class AlphabetThread : IThread
    {
        public override void SetData(Request data)
        {
           InputData = (RequestFiles) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerObjects result = WS.CreateAlphabet((RequestFiles)InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}