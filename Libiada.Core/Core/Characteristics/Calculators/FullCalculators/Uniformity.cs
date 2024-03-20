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
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        AverageRemoteness remotenessCalculator = new();
        IdentificationInformation entropyCalculator = new();
        return entropyCalculator.Calculate(chain, link) - remotenessCalculator.Calculate(chain, link);
    }
}
