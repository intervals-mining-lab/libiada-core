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

        /// <summary>
        /// ��� ������������� �������� ��� ������ �������� ���������
        /// </summary>
        public double PowerWeight = 4;

        /// <summary>
        /// ��� ���������������� ���������� ��� ������ �������� ���������
        /// </summary>
        public double NormalizedDistanseWeight = 2;

        /// <summary>
        /// ��� �������� ���������� ��� ������ �������� ���������
        /// </summary>
        public double DistanseWeight = 1;
    }
}