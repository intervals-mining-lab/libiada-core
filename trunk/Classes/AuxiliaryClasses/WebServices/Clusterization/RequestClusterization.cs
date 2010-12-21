using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    /// ��������� � ��������� ������� ��� �������������.
    ///</summary>
    [Serializable]
    public class RequestClusterization:Request
    {
        /// <summary>
        /// ������� � ��������� ��� �������������
        /// </summary>
        public SoapDataTable DataTable;
        /// <summary>
        /// ��� ��������� 
        /// (�� �������� ���������� ���������, 
        /// �� �������� ��� �������, 
        /// ���� ��� ��������� ��������)
        /// </summary>
        public MethodClusterization Method;
        /// <summary>
        /// ��������� ����� ���������
        /// </summary>
        public int ClusterCount;


    }
}