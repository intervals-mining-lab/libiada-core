namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Entropy.
/// Equals to Shannon's entropy when cyclic bindind is used.
/// Amount of information.
/// Amount of identifying informations (average for one element).
/// </summary>
public class IdentifyingInformation : ICongenericCalculator
{
    /// <summary>
    /// Calculation method.
    /// Calculated here using arithmetis mean interval 
    /// instead of elements frequency 
    /// based on geometric mean interval formula.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Count of identifying informations as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        double mean = new ArithmeticMean().Calculate(chain, link);

        return mean == 0 ? 0 : Math.Log(mean, 2);
    }
}
