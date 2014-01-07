using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.Misc.Iterators
{

    ///<summary>
    /// ��������� �������� �� �������.
    ///</summary>
    ///<typeparam name="ChainReturn">��� ������������ ���� (������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    ///<typeparam name="ChainToIterate">��� ���� �� ������� ������������ ��������(������� ������ BaseChain � ����� ��������������������� �����������)</typeparam>
    public interface IIterator<ChainReturn, ChainToIterate> where ChainReturn : BaseChain, new() where ChainToIterate: BaseChain,new ()
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
        ChainReturn Current();
    }
}