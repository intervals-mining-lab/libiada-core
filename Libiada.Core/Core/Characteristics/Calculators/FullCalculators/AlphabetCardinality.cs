namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Count of alphabet elements.
/// </summary>
public class AlphabetCardinality : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Alphabet cardinality as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        return sequence.Alphabet.Cardinality;
    }
}
