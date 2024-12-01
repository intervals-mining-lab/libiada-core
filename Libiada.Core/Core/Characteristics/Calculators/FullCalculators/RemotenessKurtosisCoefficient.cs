namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Kurtosis coefficient of remoteneses by intervals lengths.
/// </summary>
public class RemotenessKurtosisCoefficient : IFullCalculator
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
    /// Remoteneses kurtosis coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double remotenessStandardDeviation = new RemotenessStandardDeviation().Calculate(chain, link);
        if (remotenessStandardDeviation == 0) return 0;

        double remotenessKurtosis = new RemotenessKurtosis().Calculate(chain, link);

        return  remotenessKurtosis / (remotenessStandardDeviation * remotenessStandardDeviation * remotenessStandardDeviation * remotenessStandardDeviation);
    }
}
