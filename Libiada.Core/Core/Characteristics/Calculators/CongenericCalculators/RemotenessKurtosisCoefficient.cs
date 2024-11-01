namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness kurtosis coefficient.
/// </summary>
public class RemotenessKurtosisCoefficient : ICongenericCalculator
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
    public double Calculate(CongenericChain chain, Link link)
    {
        double remotenessStandardDeviation = new RemotenessStandardDeviation().Calculate(chain, link);
        if (remotenessStandardDeviation == 0) return 0;

        double remotenessKurtosis = new RemotenessKurtosis().Calculate(chain, link);
        
        return  remotenessKurtosis / (remotenessStandardDeviation * remotenessStandardDeviation * remotenessStandardDeviation * remotenessStandardDeviation);
    }
}
