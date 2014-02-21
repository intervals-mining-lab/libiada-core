namespace LibiadaCore.Classes.Root.Characteristics.Calculators
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
            List<int> intervals = chain.Intervals;
            double result = 1;
            for (int i = 1; i < intervals.Count - 1; i++)
            {
                result = result * intervals[i];
            }

            switch (link)
            {
                case Link.None:
                    return result;
                case Link.Start:
                    return result * intervals[0];
                case Link.End:
                    return result * intervals[intervals.Count - 1];
                case Link.Both:
                    return result * intervals[0] * intervals[intervals.Count - 1];
                case Link.Cycle:
                    return result * (intervals[0] + intervals[intervals.Count - 1] - 1);
                default:
                    throw new ArgumentException("Unknown link.");
            }
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
                temp = temp * Calculate(chain.CongenericChain(i), link);
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