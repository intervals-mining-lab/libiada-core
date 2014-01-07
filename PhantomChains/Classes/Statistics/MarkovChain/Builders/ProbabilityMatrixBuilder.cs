using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// ѕравило создани€ матрицы дл€ веро€тностной матрицы
    ///</summary>
    public class ProbabilityMatrixBuilder:IMatrixBuilder
    {
        public object Create(int alphabetPower, int i)
        {
            switch (i)
            {
                case 0:
                    return (double)0;
                case 1:
                    return new ProbabilityMatrixRow(alphabetPower, i);
                default:
                    return new ProbabilityMatrix(alphabetPower, i);
            }
        }
    }
}