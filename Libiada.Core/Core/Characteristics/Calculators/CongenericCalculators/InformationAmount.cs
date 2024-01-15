namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    using System;

    /// <summary>
    /// The complete amount of information in sequence.
    /// Entropy multiplied by length.
    /// </summary>
    public class InformationAmount : ICongenericCalculator
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var arithmeticMean = new ArithmeticMean();
            // TODO: try to calculate it using multiplied intervals
            double mean = arithmeticMean.Calculate(chain, link);
            return mean == 0 ? 0 : -Math.Log(1 / mean, 2);
        }
    }
}