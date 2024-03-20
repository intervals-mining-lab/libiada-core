namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Probability (frequency).
/// </summary>
public class Probability : NonLinkableCongenericCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Frequency of element in congeneric chain as <see cref="double"/>.
    /// </returns>
    public override double Calculate(CongenericChain chain)
    {
        ElementsCount count = new();
        Length length = new();

        return count.Calculate(chain) / length.Calculate(chain);
    }
}
