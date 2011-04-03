using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapChainOfChains:SoapChainWithCharacteristicOfChains
    {
        [XmlArrayItem(typeof(SoapUniformChainOfChains))]
        public ArrayList UniformChains = new ArrayList(); 
    }
}