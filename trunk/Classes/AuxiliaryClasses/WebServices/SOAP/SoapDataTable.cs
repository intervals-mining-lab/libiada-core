using System;
using System.Collections;
using System.Collections.Specialized;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapDataTable
    {
        [XmlArrayItem(typeof(SoapDataObject))]
        public ArrayList Objects = new ArrayList(); 
    }
}