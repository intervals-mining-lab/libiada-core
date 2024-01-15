namespace Segmenter.Model.Seekers
{
    using System.ComponentModel;

    /// <summary>
    /// Creates a method for extracting a word in the chain based on a concrete rule
    /// </summary>
    public static class WordExtractorFactory
    {
        /// <summary>
        /// The get seeker.
        /// </summary>
        /// <param name="deviationCalculationMethod">
        /// The deviation calculation method.
        /// </param>
        /// <returns>
        /// The <see cref="WordExtractor"/>.
        /// </returns>
        public static WordExtractor GetSeeker(DeviationCalculationMethod deviationCalculationMethod)
        {
            switch (deviationCalculationMethod)
            {
                case DeviationCalculationMethod.ProbabilityMethod:
                    return new ProbabilityExtractor();
                case DeviationCalculationMethod.AverageIntervalDifference:
                    return new DifferenceAverageIntervalExtractor();
                case DeviationCalculationMethod.Null:
                    return null;
                default:
                    throw new InvalidEnumArgumentException(nameof(deviationCalculationMethod), (int)deviationCalculationMethod, typeof(DeviationCalculationMethod));
            }
        }

        /// <summary>
        /// The get seeker.
        /// </summary>
        /// <param name="other">
        /// The other word extractor.
        /// </param>
        /// <returns>
        /// The <see cref="WordExtractor"/>.
        /// </returns>
        public static WordExtractor GetSeeker(WordExtractor other)
        {
            if (other is ProbabilityExtractor)
            {
                return GetSeeker(DeviationCalculationMethod.ProbabilityMethod);
            }

            if (other is DifferenceAverageIntervalExtractor)
            {
                return GetSeeker(DeviationCalculationMethod.AverageIntervalDifference);
            }

            return null;
        }
    }
}
