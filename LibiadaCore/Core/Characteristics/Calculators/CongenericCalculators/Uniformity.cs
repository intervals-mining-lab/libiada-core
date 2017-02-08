namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// The uniformity calculator.
    /// Calculates difference between entropy and average remoteness.
    /// </summary>
    public class Uniformity : ICongenericCalculator
    {
        /// <summary>
        /// Average remoteness calculator.
        /// </summary>
        private readonly ICongenericCalculator remotenessCalculator = new AverageRemoteness();

        /// <summary>
        /// Entropy calculator.
        /// </summary>
        private readonly ICongenericCalculator entropyCalculator = new IdentificationInformation();

        /// <summary>
        /// Calculation method for congeneric sequences.
        /// </summary>
        /// <param name="chain">
        /// The congeneric chain.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return entropyCalculator.Calculate(chain, link) - remotenessCalculator.Calculate(chain, link);
        }
    }
}
