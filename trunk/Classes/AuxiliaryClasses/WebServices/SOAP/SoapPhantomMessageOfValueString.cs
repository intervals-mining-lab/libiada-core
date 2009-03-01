using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapPhantomMessageOfValueString
    {
        [XmlArrayItem(typeof(SoapValueString))]
        public ArrayList Messages = new ArrayList();
    }
}