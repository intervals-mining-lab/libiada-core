namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness standard deviation.
/// </summary>
public class RemotenessStandardDeviation : ICongenericCalculator
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
    /// Remoteness standard deviation <see cref="double"/> value.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        double remotenessVariance = new RemotenessVariance().Calculate(sequence, link);

        return Math.Sqrt(remotenessVariance);
    }
}
