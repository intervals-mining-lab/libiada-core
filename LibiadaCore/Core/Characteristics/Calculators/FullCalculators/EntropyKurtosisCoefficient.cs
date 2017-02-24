﻿namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// The entropy kurtosis coefficient.
    /// </summary>
    public class EntropyKurtosisCoefficient : IFullCalculator
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
            var entropyKurtosis = new EntropyKurtosis();
            var entropyStandardDeviation = new EntropyStandardDeviation();

            double standardDeviation = entropyStandardDeviation.Calculate(chain, link);

            return standardDeviation == 0 ? 0 : entropyKurtosis.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation * standardDeviation);
        }
    }
}