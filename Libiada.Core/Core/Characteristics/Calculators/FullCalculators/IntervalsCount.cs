namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Intervals count depending on link.
/// </summary>
public class IntervalsCount : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Intervals count in the sequence as <see cref="double"/>.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        CongenericCalculators.IntervalsCount calculator = new();

        int sum = 0;
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            sum += (int)calculator.Calculate(sequence.CongenericSequence(i), link);
        }

        return sum;
    }
}
