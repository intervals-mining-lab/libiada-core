﻿namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Volume of sequence.
    /// </summary>
    public class Volume : IFullCalculator
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
        public double Calculate(Chain chain, Link link)
        {
            var calculator = new CongenericCalculators.Volume();

            double result = 1;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result *= calculator.Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}