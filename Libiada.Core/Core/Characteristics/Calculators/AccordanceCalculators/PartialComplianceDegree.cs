namespace Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// Partial compliance degree calculator.
/// </summary>
public class PartialComplianceDegree : IAccordanceCalculator
{
    /// <summary>
    /// Calculation methods.
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
        AccordanceIntervalsManager manager = new(firstSequence, secondSequence, link);
        if (manager.FilteredFirstIntervals.Count == 0)
        {
            return 0;
        }

        double result = 1;

        for (int i = 0; i < manager.FilteredFirstIntervals.Count; i++)
        {
            result *= LocalCompliance(manager.FilteredFirstIntervals[i], manager.FilteredSecondIntervals[i]);
        }

        double firstAndSecondOccurrences = manager.FirstOccurrencesCount + manager.SecondOccurrencesCount;

        double occurrencesCoefficient = 2.0 * manager.FilteredFirstIntervals.Count / firstAndSecondOccurrences;

        result = occurrencesCoefficient * Math.Pow(result, 1.0 / manager.FilteredFirstIntervals.Count);
        return result;
    }

    /// <summary>
    /// The local compliance.
    /// </summary>
    /// <param name="firstInterval">
    /// The first position.
    /// </param>
    /// <param name="secondInterval">
    /// The second position.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    private double LocalCompliance(int firstInterval, int secondInterval)
    {
        return 2 * Math.Sqrt(firstInterval * secondInterval) / (firstInterval + secondInterval);
    }
}
