using System;
using System.Collections;
using System.Xml.Serialization;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// ��������� � ������������ �������������
    ///</summary>
    [Serializable]
    public class SoapClusterizationVaraints
    {
        ///<summary>
        /// ������ ��������� �������������
        ///</summary>
        [XmlArrayItem(typeof(SoapClusterizationResult))]
        public ArrayList Variants = new ArrayList();
    }
}