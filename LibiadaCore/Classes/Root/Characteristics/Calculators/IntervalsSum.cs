namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;
    using System.Collections.Generic;

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
            List<int> intervals = chain.Intervals;
            long sum = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                sum += intervals[i];
            }

            switch (link)
            {
                case Link.Start:
                    return sum + intervals[0];
                case Link.End:
                    return sum + intervals[intervals.Count - 1];
                case Link.Both:
                    return sum + intervals[0] + intervals[intervals.Count - 1];
                case Link.Cycle:
                    return sum + intervals[intervals.Count - 1] + intervals[0] - 1;
                case Link.None:
                    return sum;
                default:
                    throw new ArgumentException("Unknown link.");
            }
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