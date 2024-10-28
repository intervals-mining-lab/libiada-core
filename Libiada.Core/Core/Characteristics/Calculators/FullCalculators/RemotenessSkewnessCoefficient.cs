namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness skewness coefficient by intervals lengths.
/// </summary>
public class RemotenessSkewnessCoefficient : IFullCalculator
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
        double remotenessStandardDeviation = new RemotenessStandardDeviation().Calculate(chain, link);
        if (remotenessStandardDeviation == 0) return 0;

        double remotenessSkewness = new RemotenessSkewness().Calculate(chain, link);

        return remotenessSkewness / (remotenessStandardDeviation * remotenessStandardDeviation * remotenessStandardDeviation);
    }
}
