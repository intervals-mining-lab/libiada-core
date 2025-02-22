namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Seuqnece's depth characteristic calculator.
/// </summary>
public class Depth : IFullCalculator
{
    /// <summary>
    /// Calculated as base 2 logarithm of multiplication
    /// of intervals between nearest elements
    /// in congeneric sequence.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Average remoteness <see cref="double"/> value.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        CongenericCalculators.Depth calculator = new();

        double result = 0;
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result += calculator.Calculate(sequence.CongenericSequence(i), link);
        }

        return result;
    }
}
