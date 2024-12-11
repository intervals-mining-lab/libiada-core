namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Standard deviation of the identifying informations in congeneric sequences (square root of variance of identifying informations).
/// Equals to entropy standard deviation when cyclic bindind is used.
/// </summary>
public class IdentifyingInformationStandardDeviation : IFullCalculator
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
    /// Identifying informations (entropy) standard deviation <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double identifyingInformationVariance = new IdentifyingInformationVariance().Calculate(chain, link);

        return Math.Sqrt(identifyingInformationVariance);
    }
}
