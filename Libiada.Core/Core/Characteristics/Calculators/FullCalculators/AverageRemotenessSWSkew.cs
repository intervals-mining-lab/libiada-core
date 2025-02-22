namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;

/// <summary>
/// The SW skew of congeneric average remotenesses.
/// </summary>
public class AverageRemotenessSWSkew : IFullCalculator
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
    /// SW skew value as <see cref="double"/>.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        DnaProcessor.CheckDnaAlphabet(sequence.Alphabet);

        double l = new AverageRemoteness().Calculate(sequence, link);
        if (l == 0) return 0;

        CongenericCalculators.AverageRemoteness congenericRemotenessCalculator = new();

        double g = congenericRemotenessCalculator.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("G")), link);
        double c = congenericRemotenessCalculator.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("C")), link);
        double a = congenericRemotenessCalculator.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("A")), link);
        double t = congenericRemotenessCalculator.Calculate(sequence.GetOrCreateCongenericSequence(new ValueString("T")), link);
        
        return ((g + c) - (a + t)) / l;
    }
}
