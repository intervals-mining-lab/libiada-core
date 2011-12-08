using System;
using System.Collections;
using System.Xml.Serialization;
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