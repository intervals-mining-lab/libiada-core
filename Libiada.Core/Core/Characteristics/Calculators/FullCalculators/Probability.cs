namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Probability (frequency).
/// </summary>
public class Probability : NonLinkableFullCalculator
{
    /// <summary>
    /// For complete (full) sequence always equals 1.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// if sequence is full then 1, otherwise percent of filled positions as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        CongenericCalculators.Probability calculator = new();

        double result = 0;
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result += calculator.Calculate(sequence.CongenericSequence(i));
        }

        return result > 1 ? 1 : result;
    }
}
