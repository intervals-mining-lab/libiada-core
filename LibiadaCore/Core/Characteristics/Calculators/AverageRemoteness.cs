namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// —редн€€ удалЄнность,
    /// логарифм по основанию 2 от среднегеометрического интервала.
    /// </summary>
    public class AverageRemoteness : ICalculator
    {
        /// <summary>
        ///  Calculator of average geometric of intervals lengths.
        /// </summary>
        private readonly ICalculator geometricMean = new GeometricMean();

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
        /// Average remoteness <see cref="double"/> value.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return Math.Log(geometricMean.Calculate(chain, link), 2);
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
        /// Average remoteness <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return Math.Log(geometricMean.Calculate(chain, link), 2);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverageRemoteness;
        }
    }
}