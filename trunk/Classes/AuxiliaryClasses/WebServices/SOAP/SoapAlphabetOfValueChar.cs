using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapAlphabetOfValueChar
    {
        [XmlArrayItem(typeof(SoapValueChar))]
        public ArrayList Elements = new ArrayList();
    }
}