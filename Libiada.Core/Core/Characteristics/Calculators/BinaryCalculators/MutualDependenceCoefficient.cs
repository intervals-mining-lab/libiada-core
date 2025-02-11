﻿namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// Mutual dependence coefficient of binary sequence.
/// </summary>
public class MutualDependenceCoefficient : BinaryCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="manager">
    /// Intervals manager.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Mutual dependence coefficient
    /// </returns>
    public override double Calculate(BinaryIntervalsManager manager, Link link)
    {
        // dependence of the component on itself is 0
        if (manager.FirstElement.Equals(manager.SecondElement))
        {
            return 0;
        }

        InvolvedPartialDependenceCoefficient involvedCoefficientCalculator = new();

        double firstInvolvedCoefficient = involvedCoefficientCalculator.Calculate(manager, link);
        double secondInvolvedCoefficient = involvedCoefficientCalculator.Calculate(new BinaryIntervalsManager(manager.SecondSequence, manager.FirstSequence), link);
        double multipliedInvolvedCoefficient = firstInvolvedCoefficient * secondInvolvedCoefficient;
        return (firstInvolvedCoefficient < 0 || secondInvolvedCoefficient < 0) ? 0 : Math.Sqrt(multipliedInvolvedCoefficient);
    }
}
