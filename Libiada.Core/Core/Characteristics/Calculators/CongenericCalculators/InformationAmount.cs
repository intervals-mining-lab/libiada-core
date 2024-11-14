namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The complete amount of information in sequence.
/// Entropy multiplied by intervals count.
/// </summary>
public class InformationAmount : ICongenericCalculator
{
    /// <summary>
    /// Calculation method.
    /// Calculated here using arithmetis mean interval and 
    /// intervals count instead of elements frequency and count
    /// based on geometric mean interval formula.
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
    public double Calculate(CongenericChain chain, Link link)
    {
        double mean = new ArithmeticMean().Calculate(chain, link);
        if (mean == 0) return 0;

        double intervalsCount = new IntervalsCount().Calculate(chain, link);

        return Math.Log(mean, 2) * intervalsCount;
    }
}
