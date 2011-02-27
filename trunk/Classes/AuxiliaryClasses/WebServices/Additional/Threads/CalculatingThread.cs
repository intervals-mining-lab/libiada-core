using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Calculate;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    ///</summary>
    public class CalculatingThread: IThread
    {
        private RequestFiles InputData = null;

        public override void SetData(Request data)
        {
            InputData = (RequestFiles) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerChain result = WS.Calculate(InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}