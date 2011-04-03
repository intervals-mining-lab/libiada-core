using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapChainOfValueChar:SoapChainWithCharacteristicOfValueChar
    {
        [XmlArrayItem(typeof(SoapUniformChainOfValueChar))]
        public ArrayList UniformChains = new ArrayList(); 
    }
}