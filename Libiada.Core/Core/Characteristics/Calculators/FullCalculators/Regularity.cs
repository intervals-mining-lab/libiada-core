namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Regularity of sequence.
/// </summary>
public class Regularity : IFullCalculator
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
    public double Calculate(Chain chain, Link link)
    {
        double geometricMean = new GeometricMean().Calculate(chain, link);
        double descriptiveInformation = new DescriptiveInformation().Calculate(chain, link);

        return geometricMean / descriptiveInformation;
    }
}
