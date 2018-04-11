namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// The complete amount of information in sequence.
    /// Entropy multiplied by length.
    /// </summary>
    public class InformationAmount : IFullCalculator
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 0;
            var calculator = new CongenericCalculators.InformationAmount();
            Alphabet alphabet = chain.Alphabet;
            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                result += calculator.Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}