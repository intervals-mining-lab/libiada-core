using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{
    ///<summary>
    /// �������� �������������� � ������ ���� � �����.
    ///</summary>
    ///<typeparam name="ChainReturn">��� ������������ ���� (������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    ///<typeparam name="ChainToIterate">��� ���� �� ������� ������������ ��������(������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    public class IteratorStart<ChainReturn, ChainToIterate> : IteratorBase<ChainReturn, ChainToIterate>
        where ChainToIterate : BaseChain, new()
        where ChainReturn : BaseChain, new()
    {
        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="toIterate">���� �� ������� ����� ����������� ��������</param>
        ///<param name="length">������ ������������� ��������� ����</param>
        ///<param name="step">��� ��������</param>
        ///<exception cref="Exception">� ������ ���� toIterate == null ��� ������ ������������ ���� ������ ��� ����� 0 ��� ������ length</exception>
        public IteratorStart(ChainToIterate toIterate, int length, int step)
            : base(toIterate, length, step)
        {
        }


        ///<summary>
        /// ���������� �������� �� ��������� �������.
        ///</summary>
        ///<returns>���������� False ����  ��� ����������� �������������� ����� ����. ����� True</returns>
        public override bool Next()
        {
            Position = Position + Step;
            return Position <= MaxStepCount;
        }

        ///<summary>
        /// ���������� �������� � ��������� �������.
        /// ��������� ������� ��������� -���. �� ���� ��� ���������� ������� �������� ��������� �������������� ������� Next()
        ///</summary>
        public override void Reset()
        {
            Position = -Step;
        }

        ///<summary>
        /// ���������� �������� �� �������� �������
        ///</summary>
        ///<param name="i">������� �� ������� ������������</param>
        ///<returns></returns>
        public bool Move(int i)
        {
            Position = Position + i*Step;
            return Position <= MaxStepCount;
        }
    }
}