namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Average remoteness.
/// Calculated as logarithm with base 2 from geometric mean.
/// </summary>
public class AverageRemoteness : ICongenericCalculator
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
    /// Average remoteness <see cref="double"/> value.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        double nj = new IntervalsCount().Calculate(sequence, link);
        if (nj == 0) return 0;

        double depth = new Depth().Calculate(sequence, link);
        
        return depth / nj;
    }
}
