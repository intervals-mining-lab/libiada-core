namespace Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

/// <summary>
/// The AccordanceCalculator interface.
/// </summary>
public interface IAccordanceCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="firstSequence">
    /// The first sequence.
    /// </param>
    /// <param name="secondSequence">
    /// The second sequence.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    double Calculate(CongenericSequence firstSequence, CongenericSequence secondSequence, Link link);
}
