namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness kurtosis coefficient.
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
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Standard Deviation <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double averageRemotenessStandardDeviation = new AverageRemotenessStandardDeviation().Calculate(chain, link);
        if (averageRemotenessStandardDeviation == 0) return 0;

        double averageRemotenessKurtosis = new AverageRemotenessKurtosis().Calculate(chain, link);

        return  averageRemotenessKurtosis / (averageRemotenessStandardDeviation * averageRemotenessStandardDeviation * averageRemotenessStandardDeviation * averageRemotenessStandardDeviation);
    }
}
