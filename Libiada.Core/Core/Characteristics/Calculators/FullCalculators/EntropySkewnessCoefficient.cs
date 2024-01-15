namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Normalized asymmetry of average remoteness
/// in other words asymmetry coefficient (skewness) of average remoteness.
/// </summary>
public class EntropySkewnessCoefficient : IFullCalculator
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
        var entropySkewness = new EntropySkewness();
        var entropyStandardDeviation = new EntropyStandardDeviation();

        double standardDeviation = entropyStandardDeviation.Calculate(chain, link);

        return standardDeviation == 0 ? 0 : entropySkewness.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation);
    }
}
