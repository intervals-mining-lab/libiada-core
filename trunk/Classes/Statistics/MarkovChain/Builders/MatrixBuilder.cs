using ChainAnalises.Classes.Statistics.MarkovChain.Builders;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// ������� �������� ������� ��� ������� ���������� ���������
    ///</summary>
    public class MatrixBuilder : IMatrixBuilder
    {
        ///<summary>
        /// ������� �������.
        ///</summary>
        ///<param name="powerOfAlphabet">�������� ��������</param>
        ///<param name="i">����������� �������</param>
        ///<returns>������� �������</returns>
        public object Create(int powerOfAlphabet, int i)
        {
            switch (i)
            {
                case 0:
                    return (double) 0;
                case 1:
                    return new MatrixRow(powerOfAlphabet, i);
                default:
                    return new Matrix(powerOfAlphabet, i);
            }
        }
    }
}