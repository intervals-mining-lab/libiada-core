namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Entropy.
/// Amount of information.
/// Amount of identifying information (average for one element).
/// Shannon information.
/// Shannon entropy.
/// </summary>
public class IdentificationInformation : ICongenericCalculator
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
    /// Count of identification informations as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        double mean = new ArithmeticMean().Calculate(chain, link);

        return mean == 0 ? 0 : Math.Log(mean, 2);
    }
}
