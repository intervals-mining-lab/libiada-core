namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Standard deviation of average remoteness (square root of dispersion of average remoteness).
    /// </summary>
    public class AverageRemotenessStandardDeviation : IFullCalculator
    {
        /// <summary>
        /// The average remoteness dispersion.
        /// </summary>
        private readonly IFullCalculator averageRemotenessDispersion = new AverageRemotenessDispersion();

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
            return Math.Sqrt(averageRemotenessDispersion.Calculate(chain, link));
        }
    }
}