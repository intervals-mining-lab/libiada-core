using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class SoapCluster
    {
        [XmlArrayItem(typeof(int))]
        public ArrayList Items = new ArrayList();
    }
}