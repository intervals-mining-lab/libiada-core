using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapUniformChainOfValueChar:SoapChainWithCharacteristicOfValueChar
    {
        public SoapValueChar Message = null;
    }
}