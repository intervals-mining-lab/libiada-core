using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapSpaceOfValueChar
    {
        public Int64[] Building = null;
        public SoapAlphabetOfValueChar Alphabet = null;
        [XmlArrayItem(typeof(SoapDimension))]
        public ArrayList Dimensions = new ArrayList();
    }
}