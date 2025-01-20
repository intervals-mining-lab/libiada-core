namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// The GC ratio of congeneric average remotenesses.
/// </summary>
public class AverageRemotenessGCRatio : IFullCalculator
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
    /// G+C Ratio value as <see cref="double"/>.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        DnaProcessor.CheckDnaAlphabet(sequence.Alphabet);

        double l = new AverageRemoteness().Calculate(sequence, link);
        if (l == 0) return 0;

        CongenericCalculators.AverageRemoteness congenericRemotenessCalculator = new();

        double g = congenericRemotenessCalculator.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("G")), link);
        double c = congenericRemotenessCalculator.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("C")), link);

        return 100 * (g + c) / l;
    }
}
