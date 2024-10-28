namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The entropy kurtosis coefficient.
/// </summary>
public class EntropyKurtosisCoefficient : IFullCalculator
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

        double entropyKurtosis = new EntropyKurtosis().Calculate(chain, link);

        return entropyKurtosis / (entropyStandardDeviation * entropyStandardDeviation * entropyStandardDeviation * entropyStandardDeviation);
    }
}
