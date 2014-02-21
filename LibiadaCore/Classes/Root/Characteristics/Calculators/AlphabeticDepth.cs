namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Depth with logarithm base equals cardinality of alphabet.
    /// </summary>
    public class AlphabeticDepth : ICalculator
    {
        /// <summary>
        /// The alphabet cardinality.
        /// </summary>
        private int alphabetCardinality;

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
        /// <see cref="double"/> value of alphabetic average remoteness.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if method is called not from <see cref="Calculate(LibiadaCore.Classes.Root.Chain,LibiadaCore.Classes.Root.Link)"/> and alphabet cardinality is unknown.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
        public double Calculate(CongenericChain chain, Link link)
        {
            if (alphabetCardinality == default(int))
            {
                throw new InvalidOperationException("Глубина в масштабе алфавита может вычисляться только для полной цепи.");
            }

            List<int> intervals = chain.Intervals;
            double result = 0;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                result += Math.Log(intervals[i], alphabetCardinality);
            }

            switch (link)
            {
                case Link.Start:
                    return result + Math.Log(intervals[0], alphabetCardinality);
                case Link.End:
                    return result + Math.Log(intervals[intervals.Count - 1], alphabetCardinality);
                case Link.Both:
                    return result + Math.Log(intervals[0], alphabetCardinality) +
                        Math.Log(intervals[intervals.Count - 1], alphabetCardinality);
                case Link.Cycle:
                    return result + Math.Log(intervals[intervals.Count - 1] + intervals[0] - 1, alphabetCardinality);
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
        /// <see cref="double"/> value of alphabetic average remoteness.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            alphabetCardinality = chain.Alphabet.Cardinality;
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
            return CharacteristicsEnum.AlphabeticDepth;
        }
    }
}