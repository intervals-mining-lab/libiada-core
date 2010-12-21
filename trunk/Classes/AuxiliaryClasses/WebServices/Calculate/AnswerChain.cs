using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

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