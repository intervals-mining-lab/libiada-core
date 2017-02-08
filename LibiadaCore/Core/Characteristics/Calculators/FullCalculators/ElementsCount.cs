namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Elements count.
    /// </summary>
    public class ElementsCount : IFullCalculator
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
        public double Calculate(Chain chain, Link link)
        {
            double count = 0;
            var calculator = new CongenericCalculators.ElementsCount();

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                count += calculator.Calculate(chain.CongenericChain(i), link);
            }

            return (int)count;
        }
    }
}
