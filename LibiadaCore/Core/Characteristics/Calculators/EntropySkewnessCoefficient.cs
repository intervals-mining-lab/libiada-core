namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Normalized asymmetry of average remoteness
    /// in other words asymmetry coefficient (skewness) of average remoteness.
    /// </summary>
    public class EntropySkewnessCoefficient : IFullCalculator
    {
        /// <summary>
        /// Average remoteness skewness.
        /// </summary>
        private readonly IFullCalculator entropySkewness = new EntropySkewness();

        /// <summary>
        /// Average remoteness standard deviation.
        /// </summary>
        private readonly IFullCalculator entropyStandardDeviation = new EntropyStandardDeviation();

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
        /// Standard Deviation <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double standardDeviation = entropyStandardDeviation.Calculate(chain, link);

            return standardDeviation == 0 ? 0 : entropySkewness.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation);
        }
    }
}
