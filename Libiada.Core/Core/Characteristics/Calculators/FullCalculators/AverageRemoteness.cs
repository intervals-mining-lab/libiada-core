namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Average remoteness.
/// Calculated as logarithm with base 2 from geometric mean.
/// </summary>
public class AverageRemoteness : IFullCalculator
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
    /// Average remoteness <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        Depth depthCalculator = new();
        IntervalsCount intervalsCount = new();

        double depth = depthCalculator.Calculate(chain, link);
        int nj = (int)intervalsCount.Calculate(chain, link);
        return nj == 0 ? 0 : depth / nj;
    }
}
