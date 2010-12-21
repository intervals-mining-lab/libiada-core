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
    /// Soap ����� ��������������� ������ <see cref="DataTable"/>.
    /// �������� ��� �������� ������ ��� ������������� 
    /// � ���� ������� �������� ���� <see cref="SoapDataObject"/>.
    ///</summary>
    [Serializable]
    public class SoapDataTable
    {
        ///<summary>
        /// ���������� ������ �������� ��� �������������.
        /// ��� ������� ���� ��� <see cref="SoapDataObject"/>.
        ///</summary>
        [XmlArrayItem(typeof(SoapDataObject))]
        public ArrayList Objects = new ArrayList(); 
    }
}