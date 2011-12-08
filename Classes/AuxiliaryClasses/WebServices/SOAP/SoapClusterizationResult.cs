using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// ������ ������������� ��������
    ///</summary>
    [Serializable]
    public class SoapClusterizationResult
    {
        ///<summary>
        /// ������ ���������
        ///</summary>
        [XmlArrayItem(typeof(SoapCluster))]
        public ArrayList Clusters = new ArrayList();
        ///<summary>
        /// ���������� �������� ���������
        ///</summary>
        public Double Quality = 0;
    }
}