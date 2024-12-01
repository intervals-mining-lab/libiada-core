namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Standard deviation of average remoteness in congeneric sequernces (square root of variance of average remoteness).
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
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Average remoteness standard Deviation <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double averageRemotenessVariance = new AverageRemotenessVariance().Calculate(chain, link);

        return Math.Sqrt(averageRemotenessVariance);
    }
}
