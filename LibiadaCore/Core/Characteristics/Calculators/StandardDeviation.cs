namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// СКО средних удаленностей (квадратный корень дисперсии средней удаленности)
    /// </summary>
    public class StandardDeviation : ICalculator
    {
        /// <summary>
        /// The average remoteness dispersion.
        /// </summary>
        private readonly ICalculator averageRemotenessDispersion = new AverageRemotenessDispersion();

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
        /// Standard Deviation <see cref="double"/> value.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            throw new InvalidOperationException("СКО средней удаленности вычисляется только для полных цепей.");
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
        /// Standard Deviation <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 0;
            result = Math.Sqrt(averageRemotenessDispersion.Calculate(chain, link));
            return result;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.StandardDeviation;
        }
    }
}