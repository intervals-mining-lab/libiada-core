using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// Варинт классификации объектов
    ///</summary>
    [Serializable]
    public class SoapClusterizationResult
    {
        ///<summary>
        /// Массив кластеров
        ///</summary>
        [XmlArrayItem(typeof(SoapCluster))]
        public ArrayList Clusters = new ArrayList();
        ///<summary>
        /// Показатель качества разбиения
        ///</summary>
        public Double Quality = 0;
    }
}