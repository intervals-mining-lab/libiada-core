namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// The average remoteness kurtosis coefficient.
    /// </summary>
    public class AverageRemotenessKurtosisCoefficient : IFullCalculator
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
        /// Standard Deviation <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            var averageRemotenessKurtosis = new AverageRemotenessKurtosis();
            var averageRemotenessStandardDeviation = new AverageRemotenessStandardDeviation();

            double standardDeviation = averageRemotenessStandardDeviation.Calculate(chain, link);
            return standardDeviation == 0 ? 0 : averageRemotenessKurtosis.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation * standardDeviation);
        }
    }
}
