using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapFrequencyList
    {
        [XmlArrayItem(typeof(SoapFrequencyListItem))]
        public ArrayList Elements = new ArrayList();
    }
}