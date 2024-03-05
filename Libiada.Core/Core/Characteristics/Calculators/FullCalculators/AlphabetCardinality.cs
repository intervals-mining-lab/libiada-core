namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Count of alphabet elements.
/// </summary>
public class AlphabetCardinality : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Alphabet cardinality as <see cref="double"/>.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        return chain.Alphabet.Cardinality;
    }
}
