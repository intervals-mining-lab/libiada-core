namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Normalized asymmetry of average remoteness
/// in other words asymmetry coefficient (skewness) of average remoteness.
/// </summary>
public class AverageRemotenessSkewnessCoefficient : IFullCalculator
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
        double averageRemotenessStandardDeviation = new AverageRemotenessStandardDeviation().Calculate(chain, link);
        if (averageRemotenessStandardDeviation == 0) return 0;

        double averageRemotenessSkewness = new AverageRemotenessSkewness().Calculate(chain, link);

        return averageRemotenessSkewness / (averageRemotenessStandardDeviation * averageRemotenessStandardDeviation * averageRemotenessStandardDeviation);
    }
}
