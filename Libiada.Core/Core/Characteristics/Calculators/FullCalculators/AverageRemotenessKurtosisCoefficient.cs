namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Kurtosis coefficient of average remotenesses in congeneric sequences.
/// </summary>
public class AverageRemotenessKurtosisCoefficient : IFullCalculator
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
    /// Average remoteness kurtosis coefficient <see cref="double"/> value.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double averageRemotenessStandardDeviation = new AverageRemotenessStandardDeviation().Calculate(sequence, link);
        if (averageRemotenessStandardDeviation == 0) return 0;

        double averageRemotenessKurtosis = new AverageRemotenessKurtosis().Calculate(sequence, link);

        return  averageRemotenessKurtosis / (averageRemotenessStandardDeviation * averageRemotenessStandardDeviation * averageRemotenessStandardDeviation * averageRemotenessStandardDeviation);
    }
}
