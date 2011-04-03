using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class MarkovChainThread : IThread
    {
        public override void SetData(Request data)
        {
            InputData = (RequestMarkovChain) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerMarkovChain result = WS.GenerateMarkovChains((RequestMarkovChain)InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}