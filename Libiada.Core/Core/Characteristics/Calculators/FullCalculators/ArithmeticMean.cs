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
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of average arithmetic of intervals lengths.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double intervalsCount = new IntervalsCount().Calculate(sequence, link);
        if (intervalsCount == 0) return 0;

        double intervalsSum = new IntervalsSum().Calculate(sequence, link);
        return intervalsSum / intervalsCount;
    }
}
