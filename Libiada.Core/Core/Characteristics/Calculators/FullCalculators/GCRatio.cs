﻿namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

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

        double l = new ElementsCount().Calculate(chain);
        if (l == 0) return 0;

        CongenericCalculators.ElementsCount congenericCounter = new();

        double g = congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("G")));
        double c = congenericCounter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("C")));

        return 100 * (g + c) / l;
    }
}
