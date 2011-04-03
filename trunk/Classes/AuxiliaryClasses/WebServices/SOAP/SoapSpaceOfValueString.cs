using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapSpaceOfValueString
    {
        public Int64[] Building = null;
        public SoapAlphabetOfValueString Alphabet = null;
        [XmlArrayItem(typeof(SoapDimension))]
        public ArrayList Dimensions = new ArrayList();
    }
}