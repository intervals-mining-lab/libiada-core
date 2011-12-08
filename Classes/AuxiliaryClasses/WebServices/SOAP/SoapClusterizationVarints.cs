using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// Контейнер с результатами кластеризаций
    ///</summary>
    [Serializable]
    public class SoapClusterizationVaraints
    {
        ///<summary>
        /// Массив вариантов кластеризации
        ///</summary>
        [XmlArrayItem(typeof(SoapClusterizationResult))]
        public ArrayList Variants = new ArrayList();
    }
}