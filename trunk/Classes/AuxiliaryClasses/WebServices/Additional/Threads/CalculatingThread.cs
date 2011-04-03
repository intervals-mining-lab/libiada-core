using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Calculate;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    ///</summary>
    public class CalculatingThread: IThread
    {
        public override void SetData(Request data)
        {
            InputData = (RequestFiles) data;
        }

        public override void Calculate()
        {
            WebServices WS = new WebServices();
            AnswerChain result = WS.Calculate((RequestFiles)InputData);
            lock (ResultsTable.SyncRoot)
            {
                ResultsTable.Add(hashvalue, result);
            }
        }
    }
}