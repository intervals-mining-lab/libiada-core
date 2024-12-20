﻿namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// Statistical genetic characteristic AT skew.
/// </summary>
public class ATSkew : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// AT skew value as <see cref="double"/>.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        DnaProcessor.CheckDnaAlphabet(chain.Alphabet);

        CongenericCalculators.ElementsCount counter = new();

        double a = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("A")));
        double t = counter.Calculate(chain.GetOrCreateCongenericChain(new ValueString("T")));

        return a + t == 0 ? 0 : (a - t) / (a + t);
    }
}
