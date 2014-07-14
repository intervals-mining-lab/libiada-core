namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Периодичность.
    /// Имеет смысл только для однородной цепи.
    /// </summary>
    public class Periodicity : ICalculator
    {
        /// <summary>
        /// Average geometric interval calculator.
        /// </summary>
        private readonly ICalculator geometricMean = new GeometricMean();

        /// <summary>
        /// Average arithmetic interval calculator.
        /// </summary>
        private readonly ICalculator arithmeticMean = new ArithmeticMean();

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
        /// Periodicity as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return geometricMean.Calculate(chain, link) / arithmeticMean.Calculate(chain, link);
        }

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
        /// Periodicity as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return geometricMean.Calculate(chain, link) / arithmeticMean.Calculate(chain, link);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Periodicity;
        }
    }
}