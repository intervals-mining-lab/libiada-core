using System;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators
{

    ///<summary>
    /// �������� �������������� � ����� ���� � ������.
    ///</summary>
    ///<typeparam name="ChainReturn">��� ������������ ���� (������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    ///<typeparam name="ChainToIterate">��� ���� �� ������� ������������ ��������(������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    public class IteratorEnd<ChainReturn, ChainToIterate> : IteratorBase<ChainReturn, ChainToIterate> where ChainToIterate : BaseChain, new() where ChainReturn : BaseChain, new()
    {

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="toIterate">���� �� ������� ����� ����������� ��������</param>
        ///<param name="length">������ ������������� ��������� ����</param>
        ///<param name="step">��� ��������</param>
        ///<exception cref="Exception">� ������ ���� toIterate == null ��� ������ ������������ ���� ������ ��� ����� 0 ��� ������ length</exception>
        public IteratorEnd(ChainToIterate toIterate, int length, int step) : base(toIterate, length, step)
        {
        }

        ///<summary>
        /// ���������� �������� �� ��������� �������.
        ///</summary>
        ///<returns>���������� False ����  ��� ����������� �������������� ������ ����. ����� True</returns>
        public override bool Next()
        {
            pos = pos - pStep;
            return pos >= 0;
        }


        ///<summary>
        /// ���������� �������� � ��������� �������.
        /// ��� ���������� ������� �������� ��������� �������������� ������� Next()
        ///</summary>
        public override void Reset()
        {
            pos = ptoIterate.Length - pLength + pStep;
        }
    }
}