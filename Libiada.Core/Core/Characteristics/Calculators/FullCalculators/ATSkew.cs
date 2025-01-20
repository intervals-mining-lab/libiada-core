namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

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
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// AT skew value as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        DnaProcessor.CheckDnaAlphabet(sequence.Alphabet);

        CongenericCalculators.ElementsCount counter = new();

        double a = counter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("A")));
        double t = counter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("T")));

        return a + t == 0 ? 0 : (a - t) / (a + t);
    }
}
