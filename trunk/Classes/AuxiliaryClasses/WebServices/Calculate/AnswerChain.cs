using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Answers;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Calculate
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class AnswerChain:Answer 
    {
        public SoapChainOfChains Chain = null;
    }
}