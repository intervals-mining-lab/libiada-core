namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;
    using System.Linq;

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
            var intervals = chain.GetIntervals(link);

            return intervals.Sum(interval => Math.Log(interval, 2));
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