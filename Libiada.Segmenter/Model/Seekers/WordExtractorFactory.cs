namespace Libiada.Segmenter.Model.Seekers;

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
    public static WordExtractor? GetSeeker(DeviationCalculationMethod deviationCalculationMethod)
    {
        return deviationCalculationMethod switch
        {
            DeviationCalculationMethod.ProbabilityMethod => new ProbabilityExtractor(),
            DeviationCalculationMethod.AverageIntervalDifference => new DifferenceAverageIntervalExtractor(),
            DeviationCalculationMethod.Null => null,
            _ => throw new InvalidEnumArgumentException(nameof(deviationCalculationMethod), (int)deviationCalculationMethod, typeof(DeviationCalculationMethod)),
        };
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
    public static WordExtractor? GetSeeker(WordExtractor other)
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
