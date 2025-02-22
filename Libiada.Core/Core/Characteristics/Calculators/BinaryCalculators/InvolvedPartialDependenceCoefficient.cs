namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// Involved partial dependence coefficient of binary sequence.
/// </summary>
public class InvolvedPartialDependenceCoefficient : BinaryCalculator
{
    /// <summary>
    /// Calculates involved partial dependence coefficient of binary sequence.
    /// </summary>
    /// <param name="manager">
    /// Intervals manager.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Involved partial dependence coefficient.
    /// </returns>
    public override double Calculate(BinaryIntervalsManager manager, Link link)
    {
        // dependence of the component on itself is 0
        if (manager.FirstElement.Equals(manager.SecondElement))
        {
            return 0;
        }

        Redundancy redundancyCalculator = new();

        double redundancy = redundancyCalculator.Calculate(manager, link);
        return redundancy * (2 * manager.PairsCount) / (manager.FirstSequence.OccurrencesCount + manager.SecondSequence.OccurrencesCount);
    }
}
