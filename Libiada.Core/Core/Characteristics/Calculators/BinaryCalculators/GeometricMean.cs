namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// Average geometric value of interval length.
/// </summary>
public class GeometricMean : BinaryCalculator
{
    /// <summary>
    /// Calculated as geometric mean between two congeneric sequences.
    /// </summary>
    /// <param name="manager">
    /// Intervals manager.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Average geometric value.
    /// </returns>
    public override double Calculate(BinaryIntervalsManager manager, Link link)
    {
        // dependence of the component on itself is 0
        if (manager.FirstElement.Equals(manager.SecondElement))
        {
            return 0;
        }

        int[] intervals = manager.GetIntervals();

        double result = intervals.Where(t => t > 0).Sum(t => Math.Log(t, 2));

        return Math.Pow(2, intervals.Length == 0 ? 0 : result / intervals.Length);
    }
}
