using System;

namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Entropy.
    /// Amount of information.
    /// Amount of identifying information (average for one element).
    /// Shannon information.
    /// Shannon entropy.
    /// </summary>
    public class IdentificationInformation : ICongenericCalculator
    {
        /// <summary>
        /// Average arithmetic interval length calculator.
        /// </summary>
        private readonly ICongenericCalculator arithmeticMean = new ArithmeticMean();

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
        /// Identification informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            double mean = arithmeticMean.Calculate(chain, link);

            return mean == 0 ? 0 : (-1 / mean) * Math.Log(1 / mean, 2);
        }
    }
}
