namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Вероятность (частота).
    /// </summary>
    public class Probability : ICalculator
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
        /// Frequency of element in congeneric chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var count = new ElementsCount();
            var length = new Length();
            return count.Calculate(chain, link) / length.Calculate(chain, link);
        }

        /// <summary>
        /// Для неоднородной, заполненной цепи всегда равна 1.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// if chain is full then 1, otherwise percent of filled positions as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double temp = 0;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                temp += this.Calculate(chain.CongenericChain(i), link);
            }

            return temp > 1 ? 1 : temp;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Probability;
        }
    }
}
