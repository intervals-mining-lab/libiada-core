﻿namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;
    using System.Linq;

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
            if (alphabetCardinality == default(int))
            {
                throw new InvalidOperationException("Глубина в масштабе алфавита может вычисляться только для полной цепи.");
            }

            int[] intervals = chain.GetIntervals(link);

            return intervals.Sum(interval => Math.Log(interval, alphabetCardinality));
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