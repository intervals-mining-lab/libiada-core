namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Periodicity.
/// </summary>
public class Periodicity : IFullCalculator
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
    /// Periodicity as <see cref="double"/>.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double arithmeticMean = new ArithmeticMean().Calculate(sequence, link);
        if (arithmeticMean == 0) return 0;

        double geometricMean = new GeometricMean().Calculate(sequence, link);
        
        return geometricMean / arithmeticMean;
    }
}
