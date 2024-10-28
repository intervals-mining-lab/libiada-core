namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The total amount of information in sequence.
/// Entropy multiplied by intervals count.
/// </summary>
public class InformationAmount : IFullCalculator
{
    /// <summary>
    /// The calculate.
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
        double entropy = new IdentificationInformation().Calculate(chain, link);
        double intervalsCount = new IntervalsCount().Calculate(chain, link);

        return entropy * intervalsCount;
    }
}
