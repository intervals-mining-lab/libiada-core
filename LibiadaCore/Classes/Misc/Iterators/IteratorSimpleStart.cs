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
        protected int Length;
        ///<summary>
        /// ��� ��������
        ///</summary>
        protected int Step;
        ///<summary>
        /// ���� �� ������� ����� ����������� ��������
        ///</summary>
        protected ChainToIterate chain;
        ///<summary>
        /// ������� ������� ���������
        ///</summary>
        protected int Position;
        ///<summary>
        /// ������������ ���-�� ��������
        ///</summary>
        protected int MaxCount;


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
            Length = 1;
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
        public  bool Next()
        {
            Position = Position + Step;
            return Position <= MaxStepCount;
        }


        ///<summary>
        /// ���������� ������� �������� ���������.
        ///</summary>
        ///<returns>������� �������� ���������.</returns>
        ///<exception cref="Exception">� ������ ���� �������� �������  �������� �� ��������� ����</exception>
        public virtual IBaseObject Current()
        {
            if (Position < 0 || Position > MaxCount)
            {
                return null;
            }
            return (chain[Position]).Clone();
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public int ActualPosition()
        {
            return Position;
        }


        ///<summary>
        /// ���������� �������� � ��������� �������.
        /// ��������� ������� ��������� -���. �� ���� ��� ���������� ������� �������� ��������� �������������� ������� Next()
        ///</summary>
        public void Reset()
        {
            Position = -Step;
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public bool Move(int i)
        {
            Position = Position + i * Step;
            return Position <= MaxStepCount;
        }
    }
}