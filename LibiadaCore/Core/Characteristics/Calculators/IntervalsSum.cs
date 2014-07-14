namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Суммарная длина интервалов данной цепи.
    /// </summary>
    public class IntervalsSum : ICalculator
    {
        /// <summary>
        /// Суммирует интервалы в соотвествии с привязкой
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals sum as <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
        public double Calculate(CongenericChain chain, Link link)
        {
            var intervals = chain.GetIntervals(link);

            return intervals.Sum(interval => interval);
        }

        /// <summary>
        /// Сумма всех интервалов однородных цепочек данной цепи
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals sum as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            long sum = 0;

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                sum += (long)Calculate(chain.CongenericChain(i), link);
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
            return CharacteristicsEnum.IntervalsSum;
        }
    }
}