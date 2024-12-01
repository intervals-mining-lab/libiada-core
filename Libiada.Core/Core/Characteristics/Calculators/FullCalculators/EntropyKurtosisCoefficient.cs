namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Kurtosis coefficient of the entropy in congeneric sequences.
/// </summary>
public class EntropyKurtosisCoefficient : IFullCalculator
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
    /// Entropy kurtosis coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double entropyStandardDeviation = new EntropyStandardDeviation().Calculate(chain, link);
        if (entropyStandardDeviation == 0) return 0;

        double entropyKurtosis = new EntropyKurtosis().Calculate(chain, link);

        return entropyKurtosis / (entropyStandardDeviation * entropyStandardDeviation * entropyStandardDeviation * entropyStandardDeviation);
    }
}
