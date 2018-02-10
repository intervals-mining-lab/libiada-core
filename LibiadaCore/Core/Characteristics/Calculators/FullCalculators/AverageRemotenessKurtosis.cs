namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// The average remoteness kurtosis.
    /// </summary>
    public class AverageRemotenessKurtosis : IFullCalculator
    {
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
            var averageRemoteness = new AverageRemoteness();
            var intervalsCount = new IntervalsCount();

            double result = 0;
            double g = averageRemoteness.Calculate(chain, link);
            var n = (int)intervalsCount.Calculate(chain, link);
            if (n == 0)
            {
                return 0;
            }

            var congenericIntervalsCount = new CongenericCalculators.IntervalsCount();
            var congenericAverageRemoteness = new CongenericCalculators.AverageRemoteness();
            Alphabet alphabet = chain.Alphabet;
            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(i), link);
                double gj = congenericAverageRemoteness.Calculate(chain.CongenericChain(i), link);
                double delta = gj - g;
                result += delta * delta * delta * delta * nj / n;
            }

            return result;
        }
    }
}
