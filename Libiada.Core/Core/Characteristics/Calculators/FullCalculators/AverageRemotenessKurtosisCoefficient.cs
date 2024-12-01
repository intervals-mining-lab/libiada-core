namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Kurtosis coefficient of average remotenesses in congeneric sequences.
/// </summary>
public class AverageRemotenessKurtosisCoefficient : IFullCalculator
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
    /// Average remoteness kurtosis coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double averageRemotenessStandardDeviation = new AverageRemotenessStandardDeviation().Calculate(chain, link);
        if (averageRemotenessStandardDeviation == 0) return 0;

        double averageRemotenessKurtosis = new AverageRemotenessKurtosis().Calculate(chain, link);

        return  averageRemotenessKurtosis / (averageRemotenessStandardDeviation * averageRemotenessStandardDeviation * averageRemotenessStandardDeviation * averageRemotenessStandardDeviation);
    }
}
