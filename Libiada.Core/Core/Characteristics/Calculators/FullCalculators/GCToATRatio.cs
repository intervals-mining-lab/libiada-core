namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// Statistical genetic characteristic GC to AT ratio.
/// </summary>
public class GCToATRatio : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// G+C Ratio value as <see cref="double"/> .
    /// </returns>
    public override double Calculate(Chain chain)
    {
        DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

        CongenericCalculators.ElementsCount counter = new();

        int g = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")));
        int c = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")));
        int a = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")));
        int t = (int)counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")));

        return a + t == 0 ? 0 : (g + c) / (double)(a + t);
    }
}
