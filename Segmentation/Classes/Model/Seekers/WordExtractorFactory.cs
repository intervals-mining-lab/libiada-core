namespace Segmentation.Classes.Model.Seekers
{
    /// <summary>
    /// Creates a method for extracting a word in the chain based on a concrete rule
    /// </summary>
    public class WordExtractorFactory
    {
        public static WordExtractor getSeeker(int index)
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

        public static WordExtractor getSeeker(WordExtractor obj)
        {
            if (obj is ProbabilityExtractor) return getSeeker(0);
            if (obj is DifferenceAverageIntervalExtractor) return getSeeker(1);
            return null;
        }
    }
}