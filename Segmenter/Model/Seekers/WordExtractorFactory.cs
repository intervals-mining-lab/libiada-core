namespace Segmenter.Model.Seekers
{
    using System;

    /// <summary>
    /// Creates a method for extracting a word in the chain based on a concrete rule
    /// </summary>
    public static class WordExtractorFactory
    {
        /// <summary>
        /// The get seeker.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="WordExtractor"/>.
        /// </returns>
        public static WordExtractor GetSeeker(int index)
        {
            switch (index)
            {
                case 0:
                    return new ProbabilityExtractor();
                case 1:
                    return new DifferenceAverageIntervalExtractor();
                case 2:
                    return null;
                default:
                    throw new ArgumentException("Unknown index", "index");
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
                return GetSeeker(0);
            }

            if (other is DifferenceAverageIntervalExtractor)
            {
                return GetSeeker(1);
            }

            return null;
        }
    }
}