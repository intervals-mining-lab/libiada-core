using System.Numerics;

namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Characteristic of chain depth.
/// </summary>
public class Depth : ICongenericCalculator
{
    /// <summary>
    /// Calculated as base 2 logarithm of multiplication
    /// of intervals between nearest elements
    /// in congeneric sequence.
    /// </summary>
    /// <param name="chain">
    /// Congeneric sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of depth.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        int[] intervals = chain.GetArrangement(link);
        if(intervals.Length == 0) return 0;

        BigInteger volume = 1;
        foreach(int interval in intervals) volume *= interval;

        return BigInteger.Log(volume, 2);
    }
}
