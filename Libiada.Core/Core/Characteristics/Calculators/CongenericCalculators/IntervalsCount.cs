namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Intervals count depending on link.
/// </summary>
public class IntervalsCount : ICongenericCalculator
{
    /// <summary>
    /// If link is to start, to end or cycle then intervals count equals elements count.
    /// If link is to start and end then intervals count equals elements count + 1.
    /// If link is none then intervals count equals elements count - 1.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Intervals count in sequence as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        return sequence.GetArrangement(link).Length;
    }
}
