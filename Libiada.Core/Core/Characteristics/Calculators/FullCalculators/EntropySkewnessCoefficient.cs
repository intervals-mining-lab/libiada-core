namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Normalized asymmetry of the entropy in congeneric sequences.
/// In other words asymmetry coefficient (skewness) of entropy.
/// </summary>
public class EntropySkewnessCoefficient : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// Calculated here using arithmetis mean interval and 
    /// intervals count instead of elements frequency 
    /// based on geometric mean interval formula.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Entropy skewness coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double entropyStandardDeviation = new EntropyStandardDeviation().Calculate(chain, link);
        if (entropyStandardDeviation == 0) return 0;

        double entropySkewness = new EntropySkewness().Calculate(chain, link);

        return entropySkewness / (entropyStandardDeviation * entropyStandardDeviation * entropyStandardDeviation);
    }
}
