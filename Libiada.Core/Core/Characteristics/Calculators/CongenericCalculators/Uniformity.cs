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
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        var remotenessCalculator = new AverageRemoteness();
        var entropyCalculator = new IdentificationInformation();

        return entropyCalculator.Calculate(chain, link) - remotenessCalculator.Calculate(chain, link);
    }
}
