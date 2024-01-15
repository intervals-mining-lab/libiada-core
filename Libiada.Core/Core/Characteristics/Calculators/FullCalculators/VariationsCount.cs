namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using System.Numerics;

/// <summary>
/// Count of probable sequences that can be generated
/// from given phantom sequence (sequence containing phantom messages).
/// </summary>
public class VariationsCount : NonLinkableFullCalculator
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
    public override double Calculate(Chain chain)
    {
        BigInteger count = 1;
        for (int i = 0; i < chain.Length; i++)
        {
            if (chain[i] is ValuePhantom message)
            {
                count *= message.Cardinality;
            }
        }

        return (double)count;
    }
}
