using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapSpaceOfChains
    {
        public Int64[] Building = null;
        public SoapAlphabetOfChains Alphabet = null;
        [XmlArrayItem(typeof(SoapDimension))]
        public ArrayList Dimensions = new ArrayList();
    }
}