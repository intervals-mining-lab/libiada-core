namespace Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

/// <summary>
/// The mutual compliance degree.
/// </summary>
public class MutualComplianceDegree : IAccordanceCalculator
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
    public double Calculate(CongenericSequence firstSequence, CongenericSequence secondSequence, Link link)
    {
        PartialComplianceDegree partialAccordanceCalculator = new();
        double firstResult = partialAccordanceCalculator.Calculate(firstSequence, secondSequence, link);
        double secondResult = partialAccordanceCalculator.Calculate(secondSequence, firstSequence, link);
        return Math.Sqrt(firstResult * secondResult);
    }
}
