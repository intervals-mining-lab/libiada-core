using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// Класс-кластер
    ///</summary>
    [Serializable]
    public class SoapCluster
    {
        ///<summary>
        /// Массив номеров элементов, составляющих кластер
        ///</summary>
        [XmlArrayItem(typeof(int))]
        public ArrayList Items = new ArrayList();
    }
}