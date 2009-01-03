using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapClusterizationVaraints
    {
        [XmlArrayItem(typeof(SoapClusterizationResult))]
        public ArrayList Variants = new ArrayList();
    }
}