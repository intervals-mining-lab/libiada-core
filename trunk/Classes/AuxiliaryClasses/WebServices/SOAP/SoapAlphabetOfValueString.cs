using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapAlphabetOfValueString
    {
        [XmlArrayItem(typeof(SoapValueString))]
        public ArrayList Elements = new ArrayList();
    }
}