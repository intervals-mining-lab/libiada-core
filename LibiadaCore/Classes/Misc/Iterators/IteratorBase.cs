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
        protected readonly int Length;
        ///<summary>
        /// ��� ��������
        ///</summary>
        protected readonly int Step;
        ///<summary>
        /// ���� �� ������� ����� ����������� ��������
        ///</summary>
        protected readonly ChainToIterate chain;
        ///<summary>
        /// ������� ������� ���������
        ///</summary>
        protected int Position;
        ///<summary>
        /// ������������ ���-�� ��������
        ///</summary>
        protected readonly int MaxCount;


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
            Length = length;
            Step = step;
            chain = toIterate;
            MaxCount = chain.Length - Length;
            Reset();
        }

        ///<summary>
        /// ������������ ���-�� ��������
        ///</summary>
        public int MaxStepCount
        {
            get { return MaxCount; }
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
            if (Position < 0 || Position > MaxCount)
            {
                return null;
            }

            ChainReturn temp = new ChainReturn();
            temp.ClearAndSetNewLength(Length);

            for (int i = 0; i < Length; i++)
            {
                temp.Add(chain[Position + i], i);
            }
            return temp;
        }

        public int ActualPosition()
        {
            return Position;
        }


        ///<summary>
        /// ���������� �������� � ��������� �������.
        /// ��������� ������� ��������� -1. �� ���� ��� ���������� ������� �������� ��������� �������������� ������� Next()
        ///</summary>
        public abstract void Reset();
    }
}