namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Count of probable sequences that can be generated
/// from given phantom sequence (sequence containing phantom messages).
/// </summary>
public class VariationsCount : NonLinkableCongenericCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Variations count as <see cref="double"/>.
    /// </returns>
    public override double Calculate(CongenericSequence sequence)
    {
        int count = 1;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] is ValuePhantom phantomValue)
            {
                count *= phantomValue.Cardinality;
            }
        }

        return count;
    }
}
