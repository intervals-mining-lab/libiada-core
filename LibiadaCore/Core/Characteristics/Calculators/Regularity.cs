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
        private readonly ICalculator geometricMeanCalculator = new GeometricMean();

        /// <summary>
        /// Descriptive informations calculator.
        /// </summary>
        private readonly ICalculator descriptiveInformationCalculator = new DescriptiveInformation();

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
            var geometricMean = geometricMeanCalculator.Calculate(chain, link);
            var descriptiveInformation = descriptiveInformationCalculator.Calculate(chain, link);
            return geometricMean / descriptiveInformation;
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
            var geometricMean = geometricMeanCalculator.Calculate(chain, link);
            var descriptiveInformation = descriptiveInformationCalculator.Calculate(chain, link);
            return geometricMean / descriptiveInformation;
        }
    }
}
