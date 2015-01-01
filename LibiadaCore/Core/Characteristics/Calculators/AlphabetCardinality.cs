namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Count of alphabet elements.
    /// </summary>
    public class AlphabetCardinality : IFullCalculator
    {
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
        /// Alphabet cardinality as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return chain.Alphabet.Cardinality;
        }
    }
}
