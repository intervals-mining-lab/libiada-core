namespace MarkovChains.MarkovChain.Builders
{
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// Probabilities matrix creation rule.
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
        /// The dimensionality of the matrix.
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
