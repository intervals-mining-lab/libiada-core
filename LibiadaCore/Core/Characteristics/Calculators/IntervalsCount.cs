namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Количество интервалов в зависимости от привязки.
    /// </summary>
    public class IntervalsCount : ICalculator
    {
        /// <summary>
        /// К началу, к концку и циклическая = столько же сколько элементов
        /// К обоим концам = количество элементов + 1
        /// Без привязки = количество элементов - 1
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals count in chain as <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
        public double Calculate(CongenericChain chain, Link link)
        {
            return chain.GetIntervals(link).Length;
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
        /// Intervals count in chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            int sum = 0;

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                sum += (int)Calculate(chain.CongenericChain(i), link);
            }

            return sum;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsCount;
        }
    }
}