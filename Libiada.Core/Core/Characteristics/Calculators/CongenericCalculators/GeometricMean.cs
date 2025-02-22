namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Average geometric value of interval length.
/// </summary>
public class GeometricMean : ICongenericCalculator
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
    /// Average geometric of intervals lengths as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        double intervalsCount = new IntervalsCount().Calculate(sequence, link);
        if (intervalsCount == 0) return 0;

        double remoteness = new AverageRemoteness().Calculate(sequence, link);

        return  Math.Pow(2, remoteness);
    }
}
