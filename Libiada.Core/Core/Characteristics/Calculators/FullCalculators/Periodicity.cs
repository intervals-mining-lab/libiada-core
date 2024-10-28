namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Periodicity.
/// TODO: check if it makes sense only for congeneric sequences.
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
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Periodicity as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double geometricMean = new GeometricMean().Calculate(chain, link);
        double arithmeticMean = new ArithmeticMean().Calculate(chain, link);

        return geometricMean / arithmeticMean;
    }
}
