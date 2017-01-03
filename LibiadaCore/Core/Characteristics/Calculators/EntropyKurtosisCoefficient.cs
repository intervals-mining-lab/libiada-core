namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// The entropy kurtosis coefficient.
    /// </summary>
    public class EntropyKurtosisCoefficient : IFullCalculator
    {
        /// <summary>
        /// Entropy skewness.
        /// </summary>
        private readonly IFullCalculator entropyKurtosis = new EntropyKurtosis();

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

            return standardDeviation == 0 ? 0 : entropyKurtosis.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation * standardDeviation);
        }
    }
}
