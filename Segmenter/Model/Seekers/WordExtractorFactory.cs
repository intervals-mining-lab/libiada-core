namespace Segmenter.Model.Seekers
{
    /// <summary>
    /// Creates a method for extracting a word in the chain based on a concrete rule
    /// </summary>
    public static class WordExtractorFactory
    {
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
            }

            return null;
        }

        public static WordExtractor GetSeeker(WordExtractor obj)
        {
            if (obj is ProbabilityExtractor)
            {
                return GetSeeker(0);
            }

            if (obj is DifferenceAverageIntervalExtractor)
            {
                return GetSeeker(1);
            }

            return null;
        }
    }
}