using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// ��������� ��� ������� �������� ������.
    ///</summary>
    public interface IMatrixBuilder
    {
        ///<summary>
        /// ������� ������� ������� 
        ///</summary>
        ///<param name="alph">������� ������������ � ������ �������� ������ � �������� ���������</param>
        ///<param name="i">����������� ����������� ��������</param>
        ///<returns>������ ������������� � �������� �������� �������</returns>
        object Create(int powerOfAlphabet, int i);
    }
}