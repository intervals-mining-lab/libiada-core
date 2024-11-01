namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using System.Numerics;

/// <summary>
/// Volume of sequence.
/// </summary>
public class Volume : ICongenericCalculator
{
    /// <summary>
    /// Calculated as product of all intervals in sequence.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Redundant parameter, not used in calculations.
    /// </param>
    /// <returns>
    /// Volume characteristic of chain as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        int[] intervals = chain.GetArrangement(link);
        if (intervals.Length == 0) return 1;

        BigInteger result = 1;
        foreach (int interval in intervals) result *= interval;

        return (double)result;
    }
}
