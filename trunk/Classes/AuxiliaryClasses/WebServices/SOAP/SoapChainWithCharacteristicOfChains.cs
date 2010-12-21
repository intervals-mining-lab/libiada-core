using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapChainWithCharacteristicOfChains:SoapBaseChainOfChains
    {
        [XmlArrayItem(typeof(SoapCharacteristic))]
        public ArrayList Characteristics = new ArrayList();
        public SoapFrequencyList StartIntervals = null;
        public SoapFrequencyList CommonIntervals = null;
        public SoapFrequencyList EndInterval = null;
    }
}