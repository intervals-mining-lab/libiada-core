﻿namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// The partial dependence coefficient of binary sequence.
/// </summary>
public class PartialDependenceCoefficient : BinaryCalculator
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
    /// Partial dependence coefficient.
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
        return redundancy * manager.PairsCount / manager.SecondSequence.OccurrencesCount;
    }
}
