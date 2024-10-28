namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Average arithmetic value of lengths of congeneric intervals in sequence.
/// </summary>
public class ArithmeticMean : IFullCalculator
{
    /// <summary>
    /// Calculates multiplication of all intervals
    /// between nearest similar elements in sequence
    /// divided by number of intervals.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of average arithmetic of intervals lengths.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double intervalsCount = new IntervalsCount().Calculate(chain, link);

        // if tere are no intervals arithmetic mean is equals to geometric mean
        if (intervalsCount == 0) return 1;

        double intervalsSum = new IntervalsSum().Calculate(chain, link);
        return intervalsSum / intervalsCount;
    }
}
