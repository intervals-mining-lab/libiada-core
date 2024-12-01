namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The uniformity calculator.
/// Calculates difference between entropy and average remoteness.
/// </summary>
public class Uniformity : IFullCalculator
{
    /// <summary>
    /// Calculation method for complete sequences.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double averageRemoteness = new AverageRemoteness().Calculate(chain, link);
        double entropy = new IdentificationInformation().Calculate(chain, link);

        return entropy - averageRemoteness;
    }
}
