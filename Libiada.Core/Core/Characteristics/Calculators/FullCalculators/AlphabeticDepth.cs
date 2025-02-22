namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Depth with cardinality of alphabet used as logarithm base.
/// </summary>
public class AlphabeticDepth : IFullCalculator
{
    /// <summary>
    /// Logarithm of all intervals multiplied.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/> value of alphabetic average remoteness.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double result = 0;
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        if (alphabetCardinality <= 1) return 0;

        for (int i = 0; i < alphabetCardinality; i++)
        {
            result += Calculate(sequence.CongenericSequence(i), link, alphabetCardinality);
        }

        return result;
    }

    /// <summary>
    /// Logarithm of all intervals multiplied.
    /// </summary>
    /// <param name="sequence">
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
    private double Calculate(CongenericSequence sequence, Link link, int alphabetCardinality)
    {
        int[] intervals = sequence.GetArrangement(link);
        if (intervals.Length == 0) return 0;

        return intervals.Sum(interval => Math.Log(interval, alphabetCardinality));
    }
}
