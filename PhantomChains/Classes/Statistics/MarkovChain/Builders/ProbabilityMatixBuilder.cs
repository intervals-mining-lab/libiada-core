using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// ѕравило создани€ матрицы дл€ веро€тностной матрицы
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