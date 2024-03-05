namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Elements count.
/// </summary>
public class ElementsCount : NonLinkableCongenericCalculator
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
    public override double Calculate(CongenericChain chain)
    {
        return chain.OccurrencesCount;
    }
}
