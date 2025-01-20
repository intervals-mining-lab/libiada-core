namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// Statistical genetic characteristic MK skew.
/// </summary>
public class MKSkew : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// MK skew value as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        DnaProcessor.CheckDnaAlphabet(sequence.Alphabet);

        double l = new ElementsCount().Calculate(sequence);
        if (l == 0) return 0;

        CongenericCalculators.ElementsCount congenericCounter = new();

        double g = congenericCounter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("G")));
        double c = congenericCounter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("C")));
        double a = congenericCounter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("A")));
        double t = congenericCounter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("T")));

        return ((c + a) - (g + t)) / l;
    }
}
