namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// Глубина приходящаяся на одно сообщение.
    /// </summary>
    public class NormalizedDepth : ICalculator
    {
        /// <summary>
        /// Depth calculator.
        /// </summary>
        private readonly ICalculator depth = new Depth();

        /// <summary>
        /// Chain length calculator.
        /// </summary>
        private readonly ICalculator length = new Length();

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
        /// Normalized depth as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return depth.Calculate(chain, link) / length.Calculate(chain, Link.Both);
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
        /// Normalized depth as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return depth.Calculate(chain, link) / length.Calculate(chain, Link.Both);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NormalizedDepth;
        }
    }
}