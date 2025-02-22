namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Skewness coefficient of remoteneses by intervals lengths.
/// </summary>
public class RemotenessSkewnessCoefficient : IFullCalculator
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
    /// Remoteness skewness coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double remotenessStandardDeviation = new RemotenessStandardDeviation().Calculate(sequence, link);
        if (remotenessStandardDeviation == 0) return 0;

        double remotenessSkewness = new RemotenessSkewness().Calculate(sequence, link);

        return remotenessSkewness / (remotenessStandardDeviation * remotenessStandardDeviation * remotenessStandardDeviation);
    }
}
