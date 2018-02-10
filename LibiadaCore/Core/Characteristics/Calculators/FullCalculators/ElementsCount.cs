namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Elements count.
    /// </summary>
    public class ElementsCount : NonLinkableFullCalculator
    {
        /// <summary>
        /// Amount of not empty positions,
        /// in other words elements count.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// Elements count in chain as <see cref="double"/>.
        /// </returns>
        public override double Calculate(Chain chain)
        {
            var calculator = new CongenericCalculators.ElementsCount();

            Alphabet alphabet = chain.Alphabet;
            int count = 0;
            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                count += (int)calculator.Calculate(chain.CongenericChain(i));
            }

            return count;
        }
    }
}
