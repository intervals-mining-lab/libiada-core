namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Probability (frequency).
/// </summary>
public class Probability : NonLinkableCongenericCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Frequency of element in congeneric sequence as <see cref="double"/>.
    /// </returns>
    public override double Calculate(CongenericSequence sequence)
    {
        double count = new ElementsCount().Calculate(sequence);
        double length = new Length().Calculate(sequence);

        return count / length;
    }
}
