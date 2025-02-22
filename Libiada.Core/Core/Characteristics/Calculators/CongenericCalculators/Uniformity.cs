namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The uniformity calculator.
/// Calculates difference between identifying informations (entropy) and average remoteness.
/// </summary>
public class Uniformity : ICongenericCalculator
{
    /// <summary>
    /// Calculation method for congeneric sequences.
    /// </summary>
    /// <param name="sequence">
    /// The congeneric sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        double identifyingInformation = new IdentifyingInformation().Calculate(sequence, link);
        double averageRemoteness = new AverageRemoteness().Calculate(sequence, link);

        return identifyingInformation - averageRemoteness;
    }
}
