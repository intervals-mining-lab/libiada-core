using System.Linq;

namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Volume of sequence.
    /// </summary>
    public class Volume : ICongenericCalculator
    {
        /// <summary>
        /// Calculated as product of all intervals in sequence.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Volume characteristic of chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var intervals = chain.GetIntervals(link);

            return intervals.Length == 0 ? 1 : intervals.Aggregate((result, interval) => result * interval);
        }
    }
}
