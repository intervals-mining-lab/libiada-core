namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The uniformity calculator.
/// Calculates difference between entropy and average remoteness.
/// </summary>
public class Uniformity : ICongenericCalculator
{
    /// <summary>
    /// Calculation method for congeneric sequences.
    /// </summary>
    /// <param name="chain">
    /// The congeneric chain.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        double entropy = new IdentificationInformation().Calculate(chain, link);
        double averageRemoteness = new AverageRemoteness().Calculate(chain, link);

        return entropy - averageRemoteness;
    }
}
