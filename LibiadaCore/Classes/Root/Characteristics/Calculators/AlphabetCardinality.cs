namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// Count of alphabet elements.
    /// </summary>
    public class AlphabetCardinality : ICalculator
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
        public double Calculate(CongenericChain chain, Link link)
        {
            return chain.Alphabet.Cardinality;
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
        /// Alphabet cardinality as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return chain.Alphabet.Cardinality;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AlphabetCardinality;
        }
    }
}