using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{
    ///<summary>
    ///</summary>
    ///<typeparam name="ChainToIterate"></typeparam>
    public class IteratorSimpleStart<ChainToIterate> where ChainToIterate : BaseChain, new() 
    {
        ///<summary>
        /// ������ ������������� ��������� ����
        ///</summary>
        protected int pLength;
        ///<summary>
        /// ��� ��������
        ///</summary>
        protected int pStep;
        ///<summary>
        /// ���� �� ������� ����� ����������� ��������
        ///</summary>
        protected ChainToIterate ptoIterate;
        ///<summary>
        /// ������� ������� ���������
        ///</summary>
        protected int pos;
        ///<summary>
        /// ������������ ���-�� ��������
        ///</summary>
        protected int maxcount;


        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="toIterate">���� �� ������� ����� ����������� ��������</param>
        ///<param name="step">��� ��������</param>
        ///<exception cref="Exception">� ������ ���� toIterate == null ��� ������ ������������ ���� ������ ��� ����� 0 ��� ������ length</exception>
        public IteratorSimpleStart(ChainToIterate toIterate, int step)
        {
            if (toIterate == null || toIterate.Length < 1)
            {
                throw new Exception();
            }
            pLength = 1;
            pStep = step;
            ptoIterate = toIterate;
            maxcount = ptoIterate.Length - pLength;
            Reset();
        }

        ///<summary>
        /// ������������ ���-�� ��������
        ///</summary>
        public int MaxStepCount
        {
            get { return maxcount; }
        }


        ///<summary>
        /// ���������� �������� �� ��������� �������.
        ///</summary>
        ///<returns>���������� False ����  ��� ����������� �������������� ����� ����. ����� True</returns>
        public  bool Next()
        {
            pos = pos + pStep;
            return pos <= MaxStepCount;
        }


        ///<summary>
        /// ���������� ������� �������� ���������.
        ///</summary>
        ///<returns>������� �������� ���������.</returns>
        ///<exception cref="Exception">� ������ ���� �������� �������  �������� �� ��������� ����</exception>
        public virtual IBaseObject Current()
        {
            if (pos < 0 || pos > maxcount)
            {
                return null;
            }
            return (ptoIterate[pos]).Clone();
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public int ActualPosition()
        {
            return pos;
        }


        ///<summary>
        /// ���������� �������� � ��������� �������.
        /// ��������� ������� ��������� -���. �� ���� ��� ���������� ������� �������� ��������� �������������� ������� Next()
        ///</summary>
        public void Reset()
        {
            pos = -pStep;
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public bool Move(int i)
        {
            pos = pos + i * pStep;
            return pos <= MaxStepCount;
        }
    }
}