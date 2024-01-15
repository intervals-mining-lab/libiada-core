namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Normalized asymmetry of average remoteness
    /// in other words asymmetry coefficient (skewness) of average remoteness.
    /// </summary>
    public class AverageRemotenessSkewnessCoefficient : IFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in sequence.
        /// </param>
        /// <returns>
        /// Standard Deviation <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            var averageRemotenessSkewness = new AverageRemotenessSkewness();
            var averageRemotenessStandardDeviation = new AverageRemotenessStandardDeviation();

            double standardDeviation = averageRemotenessStandardDeviation.Calculate(chain, link);
            return standardDeviation == 0 ? 0 : averageRemotenessSkewness.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation);
        }
    }
}
