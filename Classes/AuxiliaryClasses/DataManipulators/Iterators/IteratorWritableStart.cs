using System;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators
{
    ///<summary>
    /// �������� �������������� � ������ ���� � �����.
    /// ��������� ���������� �������� � ����.
    ///</summary>
    ///<typeparam name="ChainReturn">��� ������������ ���� (������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    ///<typeparam name="ChainToIterate">��� ���� �� ������� ������������ ��������(������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    public class IteratorWritableStart<ChainReturn, ChainToIterate> : IteratorStart<ChainReturn, ChainToIterate>, IWritableIterator<ChainReturn, ChainToIterate>
        where ChainToIterate : BaseChain, new() where ChainReturn : BaseChain, new()
    {
        ///<summary>
        /// �����������
        /// ������ ��������� ������������ ���� = 1.
        /// ��� �������� = 1.
        ///</summary>
        ///<param name="toIterate">���� �� ������� ����� ����������� ��������</param>
        ///<exception cref="Exception">� ������ ���� toIterate == null ��� ������ ������������ ���� ������ ��� ����� 0 ��� ������ length</exception>
        public IteratorWritableStart(ChainToIterate toIterate) : base(toIterate, 1, 1)
        {
        }


        ///<summary>
        /// ������������� �������� � ������ �� ������� ��������� ��������
        ///</summary>
        ///<param name="value">��������� ������� ����������� ������</param>
        public void SetCurrent(IBaseObject value)
        {
            ptoIterate.Add(value, pos);
        }
    }
}