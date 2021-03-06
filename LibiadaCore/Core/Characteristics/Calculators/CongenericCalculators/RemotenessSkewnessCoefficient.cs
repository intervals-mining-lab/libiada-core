﻿namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// The remoteness skewness coefficient.
    /// </summary>
    public class RemotenessSkewnessCoefficient : ICongenericCalculator
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
        public double Calculate(CongenericChain chain, Link link)
        {
            var remotenessSkewness = new RemotenessSkewness();
            var remotenessStandardDeviation = new RemotenessStandardDeviation();

            double standardDeviation = remotenessStandardDeviation.Calculate(chain, link);
            return standardDeviation == 0 ? 0 : remotenessSkewness.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation);
        }
    }
}
