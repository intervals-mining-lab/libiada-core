namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// Statistical genetic characteristic GC skew.
/// </summary>
public class GCSkew : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// G+C skew value as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        DnaProcessor.CheckDnaAlphabet(sequence.Alphabet);

        CongenericCalculators.ElementsCount counter = new();

        double g = counter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("G")));
        double c = counter.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("C")));

        return g + c == 0 ? 0 : (g - c) / (g + c);
    }
}
