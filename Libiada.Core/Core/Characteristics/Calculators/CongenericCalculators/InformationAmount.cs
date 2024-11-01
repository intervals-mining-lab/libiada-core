namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The complete amount of information in sequence.
/// Entropy multiplied by intervals count.
/// </summary>
public class InformationAmount : ICongenericCalculator
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
    public double Calculate(CongenericChain chain, Link link)
    {
        double mean = new ArithmeticMean().Calculate(chain, link);
        if (mean == 0) return 0;

        double intervalsCount = new IntervalsCount().Calculate(chain, link);

        return Math.Log(mean, 2) * intervalsCount;
    }
}
