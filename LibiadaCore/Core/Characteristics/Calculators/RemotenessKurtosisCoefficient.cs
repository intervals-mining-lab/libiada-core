﻿namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// The remoteness kurtosis coefficient.
    /// </summary>
    public class RemotenessKurtosisCoefficient : IFullCalculator
    {
        /// <summary>
        /// Average remoteness skewness.
        /// </summary>
        private readonly IFullCalculator remotenessKurtosis = new RemotenessKurtosis();

        /// <summary>
        /// Average remoteness standard deviation.
        /// </summary>
        private readonly IFullCalculator remotenessStandardDeviation = new RemotenessStandardDeviation();

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
            double standardDeviation = remotenessStandardDeviation.Calculate(chain, link);

            return remotenessKurtosis.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation * standardDeviation);
        }
    }
}