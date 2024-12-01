namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Standard deviation of remoteneses by intervals lengths.
/// </summary>
public class RemotenessStandardDeviation : IFullCalculator
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
    /// Remoteness standard deviation <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double remotenessVariance = new RemotenessVariance().Calculate(chain, link);

        return Math.Sqrt(remotenessVariance);
    }
}
