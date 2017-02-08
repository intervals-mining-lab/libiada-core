using System;

namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Standard deviation of average remoteness (square root of dispersion of average remoteness).
    /// </summary>
    public class EntropyStandardDeviation : IFullCalculator
    {
        /// <summary>
        /// The average remoteness dispersion.
        /// </summary>
        private readonly IFullCalculator entropyDispersion = new EntropyDispersion();

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
            return Math.Sqrt(entropyDispersion.Calculate(chain, link));
        }
    }
}
