namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Characteristic of chain depth.
    /// </summary>
    public class Depth : IFullCalculator
    {
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
            var calculator = new CongenericCalculators.Depth();

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result += calculator.Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}
