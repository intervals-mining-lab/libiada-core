namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The complete amount of information in sequence.
/// Identifying informations (entropy) multiplied by intervals count.
/// </summary>
public class InformationAmount : ICongenericCalculator
{
    /// <summary>
    /// Calculation method.
    /// Calculated here using arithmetis mean interval and 
    /// intervals count instead of elements frequency and count
    /// based on geometric mean interval formula.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        double identifyingInformation = new IdentifyingInformation().Calculate(sequence, link);
        double intervalsCount = new IntervalsCount().Calculate(sequence, link);

        return identifyingInformation * intervalsCount;
    }
}
