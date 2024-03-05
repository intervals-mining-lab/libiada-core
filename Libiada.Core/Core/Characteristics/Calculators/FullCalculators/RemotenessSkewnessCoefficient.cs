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
        var remotenessSkewness = new RemotenessSkewness();
        var remotenessStandardDeviation = new RemotenessStandardDeviation();

        double standardDeviation = remotenessStandardDeviation.Calculate(chain, link);
        return standardDeviation == 0 ? 0 : remotenessSkewness.Calculate(chain, link) / (standardDeviation * standardDeviation * standardDeviation);
    }
}
