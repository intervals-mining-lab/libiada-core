namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness skewness coefficient.
/// </summary>
public class RemotenessSkewnessCoefficient : ICongenericCalculator
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
    public double Calculate(CongenericSequence sequence, Link link)
    {
        double standardDeviation = new RemotenessStandardDeviation().Calculate(sequence, link);
        if (standardDeviation == 0) return 0;

        double remotenessSkewness = new RemotenessSkewness().Calculate(sequence, link);

        return remotenessSkewness / (standardDeviation * standardDeviation * standardDeviation);
    }
}
