namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Normalized average remoteness.
    /// </summary>
    public class NormalizedAverageRemoteness : ICalculator
    {
        /// <summary>
        /// Average remoteness calculator.
        /// </summary>
        private readonly ICalculator averageRemoteness = new AverageRemoteness();

        /// <summary>
        /// Alphabet cardinality calculator.
        /// </summary>
        private readonly IFullCalculator alphabetCardinality = new AlphabetCardinality();

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
        /// Normalized average remoteness as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return averageRemoteness.Calculate(chain, link);
        }

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
        /// Normalized average remoteness as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double g = averageRemoteness.Calculate(chain, link);
            double max = Math.Log(alphabetCardinality.Calculate(chain, link), 2);
            return g - max;
        }
    }
}
