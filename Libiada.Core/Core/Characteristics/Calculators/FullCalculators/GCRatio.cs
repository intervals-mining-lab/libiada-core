namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// Statistical genetic characteristic GC ratio.
/// </summary>
public class GCRatio : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// G+C Ratio value as <see cref="double"/>.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

        var congenericCounter = new CongenericCalculators.ElementsCount();
        var counter = new ElementsCount();

        var g = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")));
        var c = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")));
        var l = (int)counter.Calculate(chain);

        return l == 0 ? 0 : 100 * (g + c) / (double)l;
    }
}
