namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Average arithmetic value of lengths of congeneric intervals in sequence.
/// </summary>
public class ArithmeticMean : ICongenericCalculator
{
    /// <summary>
    /// Calculates sum of all intervals
    /// between nearest elements in congeneric sequence
    /// divided by number of intervals.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of average arithmetic of intervals lengths.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        double intervalsCount = new IntervalsCount().Calculate(chain, link);
        if (intervalsCount == 0) return 0;

        double intervalsSum = new IntervalsSum().Calculate(chain, link);

        return intervalsSum / intervalsCount;
    }
}
