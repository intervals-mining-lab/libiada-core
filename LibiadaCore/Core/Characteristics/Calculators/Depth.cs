namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Characteristic of chain depth.
    /// </summary>
    public class Depth : ICalculator
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
            var intervals = chain.GetIntervals(link);

            return intervals.Length == 0 ? 0 : intervals.Sum(interval => Math.Log(interval, 2));
        }

        /// <summary>
        /// Calculated as base 2 logarithm of multiplication 
        /// of intervals between nearest elements 
        /// in congeneric sequence.
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
            double result = 0;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result += Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}
