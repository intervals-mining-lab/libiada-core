namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// The uniformity calculator.
    /// Calculates difference between entropy and average remoteness 
    /// </summary>
    public class Uniformity : ICalculator
    {
        /// <summary>
        /// Average remoteness calculator.
        /// </summary>
        private readonly ICalculator remotenessCalculator = new AverageRemoteness();

        /// <summary>
        /// Entropy calculator.
        /// </summary>
        private readonly ICalculator entropyCalculator = new IdentificationInformation();

        /// <summary>
        /// Calculation method for complete sequences.
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
        public double Calculate(Chain chain, Link link)
        {
            return entropyCalculator.Calculate(chain, link) - remotenessCalculator.Calculate(chain, link);
        }

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