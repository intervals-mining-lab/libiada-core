using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators
{

    ///<summary>
    /// ��������� ��������� ������������ ������ �������� � ������� ����.
    /// ������ ������������� ���������� ���� � ��� ������ ���� ����� 1. 
    ///</summary>
    ///<typeparam name="ChainReturn">��� ������������ ���� (������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    ///<typeparam name="ChainToIterate">��� ���� �� ������� ������������ ��������(������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    public interface IWritableIterator<ChainReturn, ChainToIterate> : IIterator<ChainReturn, ChainToIterate> where ChainReturn : BaseChain, new() where ChainToIterate : BaseChain, new()
    {

        ///<summary>
        /// ������������� �������� � ������ �� ������� ��������� ��������
        ///</summary>
        ///<param name="value">��������� ������� ����������� ������</param>
        void SetCurrent(IBaseObject value);
    }
}