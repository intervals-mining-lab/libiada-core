namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    using System;

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
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in sequence.
        /// </param>
        /// <returns>
        /// Count of identification informations as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var arithmeticMean = new ArithmeticMean();

            double mean = arithmeticMean.Calculate(chain, link);
            return mean == 0 ? 0 : (-1 / mean) * Math.Log(1 / mean, 2);
        }
    }
}
