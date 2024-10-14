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
        EntropyKurtosis entropyKurtosis = new();
        EntropyStandardDeviation entropyStandardDeviation = new();

        double standardDeviation = entropyStandardDeviation.Calculate(chain, link);

        return standardDeviation == 0 ? 0 : entropyKurtosis.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation * standardDeviation);
    }
}
