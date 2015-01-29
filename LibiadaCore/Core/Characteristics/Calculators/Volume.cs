namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System.Linq;

    /// <summary>
    /// Volume of sequence.
    /// </summary>
    public class Volume : ICalculator
    {
        /// <summary>
        /// Calculated as multiplication of all intervals.
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

        /// <summary>
        /// Calculation method.
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
        public double Calculate(Chain chain, Link link)
        {
            double result = 1;

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result *= Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}
