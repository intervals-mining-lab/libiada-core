using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapClusterizationResult
    {
        [XmlArrayItem(typeof(SoapCluster))]
        public ArrayList Clusters = new ArrayList();
        public Double Quality = 0;
    }
}