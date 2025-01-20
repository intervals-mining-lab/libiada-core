namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Elements count.
/// </summary>
public class ElementsCount : NonLinkableFullCalculator
{
    /// <summary>
    /// Amount of not empty positions,
    /// in other words elements count.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Elements count in the sequence as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        CongenericCalculators.ElementsCount calculator = new();
        
        int count = 0;
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            count += (int)calculator.Calculate(sequence.CongenericSequence(i));
        }

        return count;
    }
}
