namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Regularity of sequence.
    /// </summary>
    public class Regularity : ICalculator
    {
        /// <summary>
        /// Average geometric interval calculator.
        /// </summary>
        private readonly ICalculator geometricMean = new GeometricMean();

        /// <summary>
        /// Descriptive informations calculator.
        /// </summary>
        private readonly ICalculator descriptiveInformation = new DescriptiveInformation();

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
        /// Regularity as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return geometricMean.Calculate(chain, link) / descriptiveInformation.Calculate(chain, link);
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
        /// Regularity as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return geometricMean.Calculate(chain, link) / descriptiveInformation.Calculate(chain, link);
        }
    }
}
