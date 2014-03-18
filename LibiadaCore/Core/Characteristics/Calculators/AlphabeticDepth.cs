namespace LibiadaCore.Core.Characteristics.Calculators
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
        /// Thrown if method is called not from <see cref="Calculate(Chain,Link)"/> and alphabet cardinality is unknown.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
        public double Calculate(CongenericChain chain, Link link)
        {
            if (this.alphabetCardinality == default(int))
            {
                throw new InvalidOperationException("Глубина в масштабе алфавита может вычисляться только для полной цепи.");
            }

            List<int> intervals = chain.GetIntervals(link);
            double result = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                result += Math.Log(intervals[i], this.alphabetCardinality);
            }

            return result;
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
            this.alphabetCardinality = chain.Alphabet.Cardinality;
            double result = 0;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result += this.Calculate(chain.CongenericChain(i), link);
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