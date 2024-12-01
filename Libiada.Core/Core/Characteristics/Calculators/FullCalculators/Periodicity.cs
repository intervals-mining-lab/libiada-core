namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Periodicity.
/// </summary>
public class Periodicity : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Periodicity as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double arithmeticMean = new ArithmeticMean().Calculate(chain, link);
        if (arithmeticMean == 0) return 0;

        double geometricMean = new GeometricMean().Calculate(chain, link);
        
        return geometricMean / arithmeticMean;
    }
}
