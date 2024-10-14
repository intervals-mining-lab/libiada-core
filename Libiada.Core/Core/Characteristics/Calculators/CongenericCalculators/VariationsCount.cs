namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Count of probable sequences that can be generated
/// from given phantom chain (sequence containing phantom messages).
/// </summary>
public class VariationsCount : NonLinkableCongenericCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Variations count as <see cref="double"/>.
    /// </returns>
    public override double Calculate(CongenericChain chain)
    {
        int count = 1;
        for (int i = 0; i < chain.Length; i++)
        {
            if (chain[i] is ValuePhantom phantomValue)
            {
                count *= phantomValue.Cardinality;
            }
        }

        return count;
    }
}
