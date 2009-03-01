using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

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