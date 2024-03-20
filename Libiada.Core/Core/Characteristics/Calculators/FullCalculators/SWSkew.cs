﻿namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// Statistical genetic characteristic SW skew.
/// </summary>
public class SWSkew : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// SW skew value as <see cref="double"/>.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

        CongenericCalculators.ElementsCount congenericCounter = new();
        ElementsCount counter = new();

        int g = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")));
        int c = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")));
        int a = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")));
        int t = (int)congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")));
        int l = (int)counter.Calculate(chain);

        return l == 0 ? 0 : ((g + c) - (a + t)) / (double)l;
    }
}
