namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// The GC skew of congeneric average remotenesses.
/// </summary>
public class AverageRemotenessGCSkew : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// G+C skew value as <see cref="double"/>.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        DnaProcessor.CheckDnaAlphabet(sequence.Alphabet);

        CongenericCalculators.AverageRemoteness congenericRemotenessCalculator = new();

        double g = congenericRemotenessCalculator.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("G")), link);
        double c = congenericRemotenessCalculator.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("C")), link);

        return g + c == 0 ? 0 : (g - c) / (g + c);
    }
}
