namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// The remoteness kurtosis coefficient.
    /// </summary>
    public class RemotenessKurtosisCoefficient : IFullCalculator
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
            var remotenessKurtosis = new RemotenessKurtosis();
            var remotenessStandardDeviation = new RemotenessStandardDeviation();

            double standardDeviation = remotenessStandardDeviation.Calculate(chain, link);
            return standardDeviation == 0 ? 0 : remotenessKurtosis.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation * standardDeviation);
        }
    }
}
