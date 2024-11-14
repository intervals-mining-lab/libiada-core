namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Normalized asymmetry of average remotenesses in congeneric sequences.
/// in other words asymmetry coefficient (skewness) of average remotenesses.
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
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Average remoteness skewness coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double averageRemotenessStandardDeviation = new AverageRemotenessStandardDeviation().Calculate(chain, link);
        if (averageRemotenessStandardDeviation == 0) return 0;

        double averageRemotenessSkewness = new AverageRemotenessSkewness().Calculate(chain, link);

        return averageRemotenessSkewness / (averageRemotenessStandardDeviation * averageRemotenessStandardDeviation * averageRemotenessStandardDeviation);
    }
}
