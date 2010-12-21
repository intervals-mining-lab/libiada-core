using System;
using System.Collections;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;


namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    /// ��������� � ������������ �������������
    ///</summary>
    [Serializable]
    public class AnswerClusterization:Answer
    {
        ///<summary>
        /// ������ � ���������� ���������
        ///</summary>
        public SoapClusterizationVaraints Variant = null;
    }
}