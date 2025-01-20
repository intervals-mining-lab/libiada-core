namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Sum of intervals lengths depending on link.
/// </summary>
public class IntervalsSum : IFullCalculator
{
    /// <summary>
    /// Sum of intervals lengths in all congeneric sequences of complete sequence.
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
    public double Calculate(ComposedSequence sequence, Link link)
    {
        CongenericCalculators.IntervalsSum calculator = new();

        int sum = 0;
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            sum += (int)calculator.Calculate(sequence.CongenericSequence(i), link);
        }

        return sum;
    }
}
