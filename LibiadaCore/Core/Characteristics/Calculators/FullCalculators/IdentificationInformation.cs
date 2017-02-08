namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Entropy.
    /// Amount of information.
    /// Amount of identifying information (average for one element).
    /// Shannon information.
    /// Shannon entropy.
    /// </summary>
    public class IdentificationInformation : IFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Identification informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            var identificationInformation = new CongenericCalculators.IdentificationInformation();

            double result = 0;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result += identificationInformation.Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}
