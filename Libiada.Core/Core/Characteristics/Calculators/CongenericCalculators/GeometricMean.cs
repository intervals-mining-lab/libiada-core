namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Average geometric value of interval length.
/// </summary>
public class GeometricMean : ICongenericCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Average geometric of intervals lengths as <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain chain, Link link)
    {
        double intervalsCount = new IntervalsCount().Calculate(chain, link);
        if (intervalsCount == 0) return 0;

        double remoteness = new AverageRemoteness().Calculate(chain, link);

        return  Math.Pow(2, remoteness);
    }
}
