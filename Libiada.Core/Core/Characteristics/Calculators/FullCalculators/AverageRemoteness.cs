namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Average remoteness.
/// Calculated as logarithm with base 2 from geometric mean.
/// </summary>
public class AverageRemoteness : IFullCalculator
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
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double n = new IntervalsCount().Calculate(sequence, link);
        if (n == 0) return 0;

        double depth = new Depth().Calculate(sequence, link);

        return depth / n;
    }
}
