namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Regularity of sequence.
    /// </summary>
    public class Regularity : ICongenericCalculator
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
        /// Regularity as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var geometricMeanCalculator = new GeometricMean();
            var descriptiveInformationCalculator = new DescriptiveInformation();

            double geometricMean = geometricMeanCalculator.Calculate(chain, link);
            double descriptiveInformation = descriptiveInformationCalculator.Calculate(chain, link);
            return geometricMean / descriptiveInformation;
        }
    }
}
