namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Regularity of sequence.
/// </summary>
public class Regularity : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Regularity as <see cref="double"/>.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double geometricMean = new GeometricMean().Calculate(sequence, link);
        double descriptiveInformation = new DescriptiveInformation().Calculate(sequence, link);

        return geometricMean / descriptiveInformation;
    }
}
