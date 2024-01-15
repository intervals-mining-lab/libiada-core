namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Average remoteness.
    /// Calculated as logarithm with base 2 from geometric mean.
    /// </summary>
    public class AverageRemoteness : ICongenericCalculator
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
        /// Average remoteness <see cref="double"/> value.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var depthCalculator = new Depth();
            var intervalsCount = new IntervalsCount();

            double depth = depthCalculator.Calculate(chain, link);
            var nj = (int)intervalsCount.Calculate(chain, link);
            return nj == 0 ? 0 : depth / nj;
        }
    }
}
