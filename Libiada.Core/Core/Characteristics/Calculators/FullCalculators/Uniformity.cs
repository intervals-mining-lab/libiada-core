namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The uniformity calculator.
/// Calculates difference between identifying informations (entropy) and average remoteness.
/// </summary>
public class Uniformity : IFullCalculator
{
    /// <summary>
    /// Calculation method for complete sequences.
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
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double averageRemoteness = new AverageRemoteness().Calculate(sequence, link);
        double identifyingInformation = new IdentifyingInformation().Calculate(sequence, link);

        return identifyingInformation - averageRemoteness;
    }
}
