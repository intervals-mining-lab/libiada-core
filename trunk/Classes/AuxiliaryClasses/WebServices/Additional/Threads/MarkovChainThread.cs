using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class MarkovChainThread : IThread
    {
        private RequestMarkovChain InputData = null;

        public override void SetData(Request data)
        {
            InputData = (RequestMarkovChain) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerMarkovChain result = WS.GenerateMarkovChains(InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}