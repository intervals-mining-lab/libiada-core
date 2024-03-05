namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Periodicity.
/// Makes sense only for congeneric sequences.
/// </summary>
public class Periodicity : ICongenericCalculator
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
    public double Calculate(CongenericChain chain, Link link)
    {
        var geometricMeanCalculator = new GeometricMean();
        var arithmeticMeanCalculator = new ArithmeticMean();

        double geometricMean = geometricMeanCalculator.Calculate(chain, link);
        double arithmeticMean = arithmeticMeanCalculator.Calculate(chain, link);
        return arithmeticMean == 0 ? 0 : geometricMean / arithmeticMean;
    }
}
