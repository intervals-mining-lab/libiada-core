namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    using System.Linq;

    /// <summary>
    /// Sum of intervals lengths depending on link.
    /// </summary>
    public class IntervalsSum : ICongenericCalculator
    {
        /// <summary>
        /// Sum of intervals lengths in congeneric sequence.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals sum as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var intervals = chain.GetIntervals(link);

            return intervals.Length == 0 ? 0 : intervals.Sum(interval => interval);
        }
    }
}
