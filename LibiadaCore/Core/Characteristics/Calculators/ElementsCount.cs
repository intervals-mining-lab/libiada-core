namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Elements count.
    /// </summary>
    public class ElementsCount : ICalculator
    {
        /// <summary>
        /// Amount of not empty positions,
        /// in other words elements count.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Elements count in chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return chain.OccurrencesCount;
        }

        /// <summary>
        /// Amount of not empty positions,
        /// in other words elements count.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Elements count in chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double count = 0;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                count += Calculate(chain.CongenericChain(i), link);
            }

            return (int)count;
        }
    }
}
