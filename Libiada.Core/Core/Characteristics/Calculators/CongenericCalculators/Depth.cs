namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using System.Numerics;

/// <summary>
/// Characteristic of sequence depth.
/// </summary>
public class Depth : ICongenericCalculator
{
    /// <summary>
    /// Calculated as base 2 logarithm of multiplication
    /// of intervals between nearest elements
    /// in congeneric sequence.
    /// </summary>
    /// <param name="sequence">
    /// Congeneric sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of depth.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        int[] intervals = sequence.GetArrangement(link);
        if(intervals.Length == 0) return 0;

        double depth = 0;
        foreach(int interval in intervals) depth += Math.Log2(interval);

        return depth;
    }
}
