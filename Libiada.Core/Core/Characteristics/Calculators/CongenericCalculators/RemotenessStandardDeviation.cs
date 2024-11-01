namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness standard deviation.
/// </summary>
public class RemotenessStandardDeviation : ICongenericCalculator
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
        double remotenessDispersion = new RemotenessDispersion().Calculate(chain, link);

        return Math.Sqrt(remotenessDispersion);
    }
}
