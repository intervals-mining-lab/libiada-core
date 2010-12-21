using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.DataMining.Clusterization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// Soap класс, соответствующий классу <see cref="DataObject"/>.
    /// Представляет собой пару эелемнтов: числовой идентификатор <see cref="id"/> 
    /// и одномерный массив объектов типа <see cref="SoapDataCharacteristic"/>.
    /// Такой объект соответствует точке в пространстве признаков.
    ///</summary>
    [Serializable]
    public class SoapDataObject
    {
        ///<summary>
        /// Идентификатор цепочки, чьи характеристики хранятся в массиве <see cref="vault"/>.
        ///</summary>
        public int id;
        ///<summary>
        /// Массив объектов типа <see cref="SoapDataCharacteristic"/>,
        /// каждый эемент хранит в себе название характеристики и её значение.
        ///</summary>
        [XmlArrayItem(typeof(SoapDataCharacteristic))] 
        public ArrayList vault = new ArrayList();
    }
}