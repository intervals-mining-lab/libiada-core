using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.DataMining.Clusterization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// Soap �����, ��������������� ������ <see cref="DataObject"/>.
    /// ������������ ����� ���� ���������: �������� ������������� <see cref="id"/> 
    /// � ���������� ������ �������� ���� <see cref="SoapDataCharacteristic"/>.
    /// ����� ������ ������������� ����� � ������������ ���������.
    ///</summary>
    [Serializable]
    public class SoapDataObject
    {
        ///<summary>
        /// ������������� �������, ��� �������������� �������� � ������� <see cref="vault"/>.
        ///</summary>
        public int id;
        ///<summary>
        /// ������ �������� ���� <see cref="SoapDataCharacteristic"/>,
        /// ������ ������ ������ � ���� �������� �������������� � � ��������.
        ///</summary>
        [XmlArrayItem(typeof(SoapDataCharacteristic))] 
        public ArrayList vault = new ArrayList();
    }
}