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
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Elements count in chain as <see cref="double"/>.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        CongenericCalculators.ElementsCount calculator = new();
        
        int count = 0;
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            count += (int)calculator.Calculate(chain.CongenericChain(i));
        }

        return count;
    }
}
