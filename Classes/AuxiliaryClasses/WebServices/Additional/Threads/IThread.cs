using System.Collections;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    /// ������������� ��������� ��������������� �������.
    ///</summary>
    public abstract class IThread
    {
        protected string hashvalue = null;
        protected Hashtable ResultsTable;
        protected Request InputData = null;

        ///<summary>
        /// ������������� �������� ������ ��� ����������.
        ///</summary>
        ///<param name="data">�������� ������</param>
        public abstract void SetData(Request data);

        ///<summary>
        /// ����� � ������� ��������������� ���-������� 
        /// � ������� ����� ������������ ��������� ����������
        ///</summary>
        ///<param name="resultContainer">���-�������</param>
        public void SetResultContainer(Hashtable resultContainer)
        {
            ResultsTable = resultContainer;
        }

        ///<summary>
        /// ������������� �������� ���-���� ��������������� ������.
        ///</summary>
        ///<param name="hash">���</param>
        public  void SetHash(string hash)
        {
            hashvalue = hash;
        }

        ///<summary>
        /// ����� ����������� ���������� �������������� ������.
        ///</summary>
        public abstract void Calculate();
    }
}
