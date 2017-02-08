namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Average remoteness.
    /// Calculated as logarithm with base 2 from geometric mean.
    /// </summary>
    public class AverageRemoteness : IFullCalculator
    {
        /// <summary>
        /// Depth characteristic calculator.
        /// </summary>
        private readonly IFullCalculator depthCalculator = new Depth();

        /// <summary>
        /// Intervals count calculator.
        /// </summary>
        private readonly IFullCalculator intervalsCount = new IntervalsCount();

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
        /// Average remoteness <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double depth = depthCalculator.Calculate(chain, link);
            int nj = (int)intervalsCount.Calculate(chain, link);

            return nj == 0 ? 0 : depth / nj;
        }
    }
}
