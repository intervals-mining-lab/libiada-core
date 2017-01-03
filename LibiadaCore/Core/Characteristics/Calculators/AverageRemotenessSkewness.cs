namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Asymmetry of average remoteness. Third central moment.
    /// </summary>
    public class AverageRemotenessSkewness : IFullCalculator
    {
        /// <summary>
        /// The average remoteness.
        /// </summary>
        private readonly ICalculator averageRemoteness = new AverageRemoteness();

        /// <summary>
        /// The intervals count.
        /// </summary>
        private readonly ICalculator intervalsCount = new IntervalsCount();

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Average remoteness dispersion <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 0;
            double g = averageRemoteness.Calculate(chain, link);
            int n = (int)intervalsCount.Calculate(chain, link);
            if (n == 0)
            {
                return 0;
            }

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                double nj = intervalsCount.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double gj = averageRemoteness.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double delta = gj - g;
                result += delta * delta * delta * nj / n;
            }

            return result;
        }
    }
}
