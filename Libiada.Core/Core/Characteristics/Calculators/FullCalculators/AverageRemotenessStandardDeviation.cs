namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Standard deviation of average remoteness (square root of dispersion of average remoteness).
/// </summary>
public class AverageRemotenessStandardDeviation : IFullCalculator
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
    /// Standard Deviation <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        AverageRemotenessDispersion averageRemotenessDispersion = new();
        return Math.Sqrt(averageRemotenessDispersion.Calculate(chain, link));
    }
}
