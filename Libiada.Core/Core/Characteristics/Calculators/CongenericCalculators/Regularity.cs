namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

// TODO: remove because it duplicates periodicity 

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
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Regularity as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        GeometricMean geometricMeanCalculator = new();
        DescriptiveInformation descriptiveInformationCalculator = new();

        double geometricMean = geometricMeanCalculator.Calculate(chain, link);
        double descriptiveInformation = descriptiveInformationCalculator.Calculate(chain, link);
        return geometricMean / descriptiveInformation;
    }
}
