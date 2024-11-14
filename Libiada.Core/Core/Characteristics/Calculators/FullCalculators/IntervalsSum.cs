namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Sum of intervals lengths depending on link.
/// </summary>
public class IntervalsSum : IFullCalculator
{
    /// <summary>
    /// Sum of intervals lengths in all congeneric sequences of complete sequence.
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
    public double Calculate(Chain chain, Link link)
    {
        CongenericCalculators.IntervalsSum calculator = new();

        int sum = 0;
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            sum += (int)calculator.Calculate(chain.CongenericChain(i), link);
        }

        return sum;
    }
}
