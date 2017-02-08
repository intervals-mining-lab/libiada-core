namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using System;

    /// <summary>
    /// The remoteness standard deviation.
    /// </summary>
    public class RemotenessStandardDeviation : IFullCalculator
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
            var remotenessDispersion = new RemotenessDispersion();
            return Math.Sqrt(remotenessDispersion.Calculate(chain, link));
        }
    }
}
