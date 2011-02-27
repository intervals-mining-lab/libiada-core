using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    internal class AlphabetThread : IThread
    {
        private RequestFiles InputData = null;

        public override void SetData(Request data)
        {
           InputData = (RequestFiles) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerObjects result = WS.CreateAlphabet(InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}