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
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// G+C Ratio value as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        DnaProcessor.CheckDnaAlphabet(sequence.Alphabet);

        double l = new ElementsCount().Calculate(sequence);
        if (l == 0) return 0;

        CongenericCalculators.ElementsCount congenericCounter = new();

        double g = congenericCounter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("G")));
        double c = congenericCounter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("C")));

        return 100 * (g + c) / l;
    }
}
