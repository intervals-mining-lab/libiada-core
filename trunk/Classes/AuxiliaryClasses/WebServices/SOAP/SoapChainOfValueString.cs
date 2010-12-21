using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapChainOfValueString : SoapChainWithCharacteristicOfValueString
    {
        [XmlArrayItem(typeof(SoapUniformChainOfValueString))]
        public ArrayList UniformChains = new ArrayList(); 
    }
}