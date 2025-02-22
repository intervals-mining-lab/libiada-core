namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// The normalized partial dependence coefficient of binary sequence.
/// </summary>
public class NormalizedPartialDependenceCoefficient : BinaryCalculator
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
    /// Normalized partial dependence coefficient.
    /// </returns>
    public override double Calculate(BinaryIntervalsManager manager, Link link)
    {
        // dependence of the component on itself is 0
        if (manager.FirstElement.Equals(manager.SecondElement))
        {
            return 0;
        }

        PartialDependenceCoefficient partialDependenceCoefficient = new();

        double k1 = partialDependenceCoefficient.Calculate(manager, link);
        return k1 * 2 * manager.PairsCount / manager.FirstSequence.Length;
    }
}
