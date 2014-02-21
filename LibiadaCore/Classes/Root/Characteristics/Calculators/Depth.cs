namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Characteristic of chain depth.
    /// </summary>
    public class Depth : ICalculator
    {
        /// <summary>
        /// Двоичный логарифм произведения всех интервалов цепочки.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of depth.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
        public double Calculate(CongenericChain chain, Link link)
        {
            List<int> intervals = chain.Intervals;
            double result = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                result += Math.Log(intervals[i], 2);
            }

            switch (link)
            {
                case Link.Start:
                    return result + Math.Log(intervals[0], 2);
                case Link.End:
                    return result + Math.Log(intervals[intervals.Count - 1], 2);
                case Link.Both:
                    return result + Math.Log(intervals[0], 2) +
                        Math.Log(intervals[intervals.Count - 1], 2);
                case Link.Cycle:
                    return result + Math.Log(intervals[intervals.Count - 1] + intervals[0] - 1, 2);
                case Link.None:
                    return result;
                default:
                    throw new ArgumentException("Unknown link.");
            }
        }

        /// <summary>
        /// Двоичный логарифм произведения всех интервалов цепочки.
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
            double result = 0;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result += Calculate(chain.CongenericChain(i), link);
            }

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
            return CharacteristicsEnum.Depth;
        }
    }
}