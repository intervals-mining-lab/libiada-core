using ChainAnalises.Classes.Statistics.MarkovChain.Builders;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// ������� �������� ������� ��� ������������� �������
    ///</summary>
    public class ProbabilityMatixBuilder:IMatrixBuilder
    {
        public object Create(int powerOfAlphabet, int i)
        {
            switch (i)
            {
                case 0:
                    return (double)0;
                case 1:
                    return new ProbabilityMatixRow(powerOfAlphabet, i);
                default:
                    return new ProbabilityMatrix(powerOfAlphabet, i);
            }
        }
    }
}