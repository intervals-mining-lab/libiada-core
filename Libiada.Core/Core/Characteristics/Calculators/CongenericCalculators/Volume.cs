namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Volume of sequence.
/// </summary>
public class Volume : ICongenericCalculator
{
    /// <summary>
    /// Calculated as product of all intervals in sequence.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Volume characteristic of the sequence as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        int[] intervals = sequence.GetArrangement(link);
        if (intervals.Length == 0) return 1;

        double result = 1;
        foreach (int interval in intervals) result *= interval;

        return result;
    }
}
