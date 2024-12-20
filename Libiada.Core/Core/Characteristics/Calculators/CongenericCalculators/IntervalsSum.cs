﻿namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Sum of intervals lengths depending on link.
/// </summary>
public class IntervalsSum : ICongenericCalculator
{
    /// <summary>
    /// Sum of intervals lengths in congeneric sequence.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Intervals sum as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        int[] intervals = chain.GetArrangement(link);

        return intervals.Length == 0 ? 0 : intervals.Sum();
    }
}
