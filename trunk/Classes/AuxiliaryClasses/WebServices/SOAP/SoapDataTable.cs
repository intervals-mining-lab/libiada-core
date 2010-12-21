using System;
using System.Collections;
using System.Collections.Specialized;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;
using ChainAnalises.Classes.DataMining.Clusterization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// Soap класс соответствующий классу <see cref="DataTable"/>.
    /// Содержит все исходные данные для кластеризации 
    /// в виде массива объектов типа <see cref="SoapDataObject"/>.
    ///</summary>
    [Serializable]
    public class SoapDataTable
    {
        ///<summary>
        /// Одномерный массив объектов для кластеризации.
        /// Все объекты имет тип <see cref="SoapDataObject"/>.
        ///</summary>
        [XmlArrayItem(typeof(SoapDataObject))]
        public ArrayList Objects = new ArrayList(); 
    }
}