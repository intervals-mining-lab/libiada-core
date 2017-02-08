using System;

namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Mazur's descriptive information.
    /// </summary>
    public class DescriptiveInformation : IFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Descriptive informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 1;
            var calculator = new CongenericCalculators.DescriptiveInformation();

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result *= calculator.Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }
    }
}
