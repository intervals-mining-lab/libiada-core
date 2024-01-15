namespace MarkovChains.MarkovCompare
{
    using MarkovChains.MarkovChain;
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// Markov chain metrics calculator.
    /// </summary>
    public class MarkovMetrics
    {
        /// <summary>
        /// Calculates arithmetical mean of all probabilities.
        /// </summary>
        /// <param name="chain">
        /// Markov chain.
        /// </param>
        /// <returns>
        /// arithmetical mean of all probabilities.
        /// </returns>
        public double GetArithmeticalMean(MarkovChainNotCongenericStatic chain)
        {
            IProbabilityMatrix matrix = chain.PropabilityMatrix;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                int[] array = { i };
                matrix.GetProbabilityVector(chain.Alphabet, array);
            }

            return 0;
        }
    }
}
