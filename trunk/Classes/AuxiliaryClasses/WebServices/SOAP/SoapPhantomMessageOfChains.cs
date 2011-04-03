using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapPhantomMessageOfChains
    {
       // [XmlArrayItem(typeof (SoapChainOfValueChar))] 
        [XmlArrayItem(typeof(SoapChainOfValueString))] 
        public ArrayList Messages = new ArrayList();
    }
}