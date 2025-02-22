namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Sum of intervals lengths depending on link.
/// </summary>
public class IntervalsSum : ICongenericCalculator
{
    /// <summary>
    /// Sum of intervals lengths in congeneric sequence.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Intervals sum as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        int[] intervals = sequence.GetArrangement(link);

        return intervals.Length == 0 ? 0 : intervals.Sum();
    }
}
