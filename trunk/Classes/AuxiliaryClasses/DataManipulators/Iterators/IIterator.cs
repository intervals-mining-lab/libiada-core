using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators
{

    ///<summary>
    /// ��������� �������� �� �������.
    ///</summary>
    ///<typeparam name="ChainRetrun">��� ������������ ���� (������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    ///<typeparam name="ChainToIterate">��� ���� �� ������� ������������ ��������(������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    public interface IIterator<ChainRetrun, ChainToIterate> where ChainRetrun : BaseChain, new() where ChainToIterate: BaseChain,new ()
    {

        ///<summary>
        /// ���������� �������� �� ��������� �������.
        ///</summary>
        ///<returns>���������� False ����  ��� ����������� �������������� ����� ����. ����� True</returns>
        bool Next();


        ///<summary>
        /// ���������� �������� � ��������� �������.
        /// ��������� ������� ��������� -��� ��������. �� ���� ��� ���������� ������� �������� ��������� �������������� ������� Next()
        ///</summary>
        void Reset();

        ///<summary>
        /// ���������� ������� �������� ���������.
        ///</summary>
        ///<returns>������� �������� ���������.</returns>
        ChainRetrun Current();
    }
}