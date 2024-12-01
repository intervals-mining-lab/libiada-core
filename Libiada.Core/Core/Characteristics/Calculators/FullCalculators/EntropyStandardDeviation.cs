namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Standard deviation of the entropy in congeneric sequences (square root of variance of entropy).
/// </summary>
public class EntropyStandardDeviation : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// Calculated here using arithmetis mean interval and 
    /// intervals count instead of elements frequency 
    /// based on geometric mean interval formula.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Entropy standard deviation <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double entropyVariance = new EntropyVariance().Calculate(chain, link);

        return Math.Sqrt(entropyVariance);
    }
}
