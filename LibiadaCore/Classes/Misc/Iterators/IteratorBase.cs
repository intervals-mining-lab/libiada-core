using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{

    ///<summary>
    /// ������� ����� �������� �� �������.
    ///</summary>
    ///<typeparam name="ChainReturn">��� ������������ ���� (������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    ///<typeparam name="ChainToIterate">��� ���� �� ������� ������������ ��������(������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    public abstract class IteratorBase<ChainReturn, ChainToIterate> : IIterator<ChainReturn, ChainToIterate> where ChainReturn : BaseChain, new() where ChainToIterate : BaseChain, new()
    {
        ///<summary>
        /// ������ ������������� ��������� ����
        ///</summary>
        protected readonly int pLength;
        ///<summary>
        /// ��� ��������
        ///</summary>
        protected readonly int pStep;
        ///<summary>
        /// ���� �� ������� ����� ����������� ��������
        ///</summary>
        protected readonly ChainToIterate ptoIterate;
        ///<summary>
        /// ������� ������� ���������
        ///</summary>
        protected int pos;
        ///<summary>
        /// ������������ ���-�� ��������
        ///</summary>
        protected readonly int maxcount;


        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="toIterate">���� �� ������� ����� ����������� ��������</param>
        ///<param name="length">������ ������������� ��������� ����</param>
        ///<param name="step">��� ��������</param>
        ///<exception cref="Exception">� ������ ���� toIterate == null ��� ������ ������������ ���� ������ ��� ����� 0 ��� ������ length</exception>
        public IteratorBase(ChainToIterate toIterate, int length, int step)
        {
            if (toIterate == null || length <= 0 || toIterate.Length < length)
            {
                throw new Exception();
            }
            pLength = length;
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
        public abstract bool Next();


        ///<summary>
        /// ���������� ������� �������� ���������.
        ///</summary>
        ///<returns>������� �������� ���������.</returns>
        ///<exception cref="Exception">� ������ ���� �������� �������  �������� �� ��������� ����</exception>
        public virtual ChainReturn Current()
        {
            if (pos < 0 || pos > maxcount)
            {
                return null;
            }

            ChainReturn temp = new ChainReturn();
            temp.ClearAndSetNewLength(pLength);

            for (int i = 0; i < pLength; i++)
            {
                temp.Add(ptoIterate[pos + i], i);
            }
            return temp;
        }

        public int ActualPosition()
        {
            return pos;
        }


        ///<summary>
        /// ���������� �������� � ��������� �������.
        /// ��������� ������� ��������� -1. �� ���� ��� ���������� ������� �������� ��������� �������������� ������� Next()
        ///</summary>
        public abstract void Reset();
    }
}