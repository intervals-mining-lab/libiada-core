using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapDataObject
    {
        public int id;
        [XmlArrayItem(typeof(SoapDataCharacteristic))] 
        public ArrayList vault = new ArrayList();
    }
}