namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Normalized asymmetry of average remoteness 
    /// in other words asymmetry coefficient (skewness) of average remoteness.
    /// </summary>
    public class AverageRemotenessSkewnessCoefficient : IFullCalculator
    {
        /// <summary>
        /// Average remoteness skewness.
        /// </summary>
        private readonly IFullCalculator averageRemotenessSkewness = new AverageRemotenessSkewness();

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

            return averageRemotenessSkewness.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation);   
        }
    }
}
