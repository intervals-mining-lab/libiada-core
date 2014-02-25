namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    using global::PhantomChains.Classes.Statistics.MarkovChain.Matrices.Probability;

    /// <summary>
    /// ������� �������� ������� ��� ������������� �������
    /// </summary>
    public class ProbabilityMatrixBuilder : IMatrixBuilder
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// The alphabet cardinality.
        /// </param>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Create(int alphabetCardinality, int i)
        {
            switch (i)
            {
                case 0:
                    return (double)0;
                case 1:
                    return new ProbabilityMatrixRow(alphabetCardinality, i);
                default:
                    return new ProbabilityMatrix(alphabetCardinality, i);
            }
        }
    }
}