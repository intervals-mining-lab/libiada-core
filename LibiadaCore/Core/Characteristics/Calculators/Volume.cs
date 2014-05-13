namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Объём цепи. Произведение длин всех её интервалов.
    /// </summary>
    public class Volume : ICalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Volume characteristic of chain as <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
        public double Calculate(CongenericChain chain, Link link)
        {
            var intervals = chain.GetIntervals(link);
            double result = 1;
            for (int i = 0; i < intervals.Length; i++)
            {
                result = result * intervals[i];
            }

            return result;
        }

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Volume characteristic of chain as <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
        public double Calculate(Chain chain, Link link)
        {
            double temp = 1;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                temp = temp * this.Calculate(chain.CongenericChain(i), link);
            }

            return temp;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Volume;
        }
    }
}