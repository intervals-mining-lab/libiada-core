namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// The average remoteness kurtosis coefficient.
    /// </summary>
    public class AverageRemotenessKurtosisCoefficient : IFullCalculator
    {
        /// <summary>
        /// Average remoteness skewness.
        /// </summary>
        private readonly IFullCalculator averageRemotenessKurtosis = new AverageRemotenessKurtosis();

        /// <summary>
        /// Average remoteness standard deviation.
        /// </summary>
        private readonly IFullCalculator averageRemotenessStandardDeviation = new AverageRemotenessStandardDeviation();

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
            double standardDeviation = averageRemotenessStandardDeviation.Calculate(chain, link);

            return standardDeviation == 0 ? 0 : averageRemotenessKurtosis.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation * standardDeviation);
        }
    }
}
