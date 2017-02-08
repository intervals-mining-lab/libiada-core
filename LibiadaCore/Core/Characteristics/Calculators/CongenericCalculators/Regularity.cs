namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Regularity of sequence.
    /// </summary>
    public class Regularity : ICongenericCalculator
    {
        /// <summary>
        /// Average geometric interval calculator.
        /// </summary>
        private readonly ICongenericCalculator geometricMeanCalculator = new GeometricMean();

        /// <summary>
        /// Descriptive informations calculator.
        /// </summary>
        private readonly ICongenericCalculator descriptiveInformationCalculator = new DescriptiveInformation();

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
    }
}
