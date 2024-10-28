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
        double entropyStandardDeviation = new EntropyStandardDeviation().Calculate(chain, link);
        if (entropyStandardDeviation == 0) return 0;

        double entropySkewness = new EntropySkewness().Calculate(chain, link);

        return entropySkewness / (entropyStandardDeviation * entropyStandardDeviation * entropyStandardDeviation);
    }
}
