using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// �����-�������
    ///</summary>
    [Serializable]
    public class SoapCluster
    {
        ///<summary>
        /// ������ ������� ���������, ������������ �������
        ///</summary>
        [XmlArrayItem(typeof(int))]
        public ArrayList Items = new ArrayList();
    }
}