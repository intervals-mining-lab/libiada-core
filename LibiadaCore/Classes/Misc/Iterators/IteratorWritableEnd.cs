using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{

    ///<summary>
    /// �������� �������������� � ����� ���� � ������.
    /// ��������� ���������� �������� � ����.
    ///</summary>
    ///<typeparam name="ChainReturn">��� ������������ ���� (������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    ///<typeparam name="ChainToIterate">��� ���� �� ������� ������������ ��������(������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    public class IteratorWritableEnd<ChainReturn, ChainToIterate> : IteratorEnd<ChainReturn, ChainToIterate>, IWritableIterator<ChainReturn, ChainToIterate>   
        where ChainToIterate : BaseChain, new() where ChainReturn : BaseChain, new()
    {
        ///<summary>
        /// �����������
        /// ������ ��������� ������������ ���� = 1.
        /// ��� �������� = 1.
        ///</summary>
        ///<param name="toIterate">���� �� ������� ����� ����������� ��������</param>
        ///<exception cref="Exception">� ������ ���� toIterate == null ��� ������ ������������ ���� ������ ��� ����� 0 ��� ������ length</exception>
        public IteratorWritableEnd(ChainToIterate toIterate) : base(toIterate, 1, 1)
        {
        }


        ///<summary>
        /// ������������� �������� � ������ �� ������� ��������� ��������
        ///</summary>
        ///<param name="baseObject">��������� ������� ����������� ������</param>
        public void SetCurrent(IBaseObject baseObject)
        {
            ptoIterate.Add(baseObject, pos);
        }
    }
}