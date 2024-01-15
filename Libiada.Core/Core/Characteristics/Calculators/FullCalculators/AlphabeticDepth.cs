namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using System;
using System.Linq;

/// <summary>
/// Depth with cardinality of alphabet used as logarithm base.
/// </summary>
public class AlphabeticDepth : IFullCalculator
{
    /// <summary>
    /// Logarithm of all intervals multiplied.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of alphabetic average remoteness.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        int alphabetCardinality = chain.Alphabet.Cardinality;
        double result = 0;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result += Calculate(chain.CongenericChain(i), link, alphabetCardinality);
        }

        return result;
    }

    /// <summary>
    /// Logarithm of all intervals multiplied.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <param name="alphabetCardinality">
    /// Complete sequence alphabet cardinality to be used as the base of the logarithm.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of alphabetic average remoteness.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if link is unknown.
    /// </exception>
    private double Calculate(CongenericChain chain, Link link, int alphabetCardinality)
    {
        int[] intervals = chain.GetArrangement(link);
        return intervals.Length == 0 ? 0 : intervals.Sum(interval => Math.Log(interval, alphabetCardinality));
    }
}
