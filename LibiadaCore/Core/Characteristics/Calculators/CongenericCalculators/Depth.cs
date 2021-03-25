namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Characteristic of chain depth.
    /// </summary>
    public class Depth : ICongenericCalculator
    {
        /// <summary>
        /// Calculated as base 2 logarithm of multiplication
        /// of intervals between nearest elements
        /// in congeneric sequence.
        /// </summary>
        /// <param name="chain">
        /// Congeneric sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of depth.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            int[] intervals = chain.GetArrangement(link);
            // TODO: try using Log of multiplied intervals
            return intervals.Length == 0 ? 0 : intervals.Sum(interval => Math.Log(interval, 2));
        }
    }
}
