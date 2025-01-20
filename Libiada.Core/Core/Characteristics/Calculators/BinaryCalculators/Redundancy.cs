namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// Redundancy of binary sequence.
/// </summary>
public class Redundancy : BinaryCalculator
{
    // TODO: refactor to using intervals manager

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
    /// Redundancy as <see cref="double"/>.
    /// </returns>
    public override double Calculate(BinaryIntervalsManager manager, Link link)
    {
        // dependence of the component on itself is 0
        if (manager.FirstElement.Equals(manager.SecondElement))
        {
            return 0;
        }

        int firstElementCount = manager.FirstSequence.OccurrencesCount;
        double avG = 0;
        int currentEntrance = 0;
        for (int i = 1; i <= firstElementCount; i++)
        {
            if (manager.GetBinaryInterval(i) > 0)
            {
                if (currentEntrance == 0)
                {
                    currentEntrance = manager.GetFirstAfter(manager.GetFirst(i));
                    if (link == Link.Start || link == Link.Both)
                    {
                        avG += Math.Log(currentEntrance, 2);
                    }
                }
                else
                {
                    int nextEntrance = manager.GetFirstAfter(manager.GetFirst(i));
                    avG += Math.Log(nextEntrance - currentEntrance, 2);
                    currentEntrance = nextEntrance;
                }
            }
        }

        if (link == Link.End || link == Link.Both)
        {
            avG += Math.Log(manager.Length - currentEntrance, 2);
        }

        avG = manager.PairsCount == 0 ? 0 : avG / manager.PairsCount;

        GeometricMean geometricMeanCalculator = new();

        double binaryGeometricMean = geometricMeanCalculator.Calculate(manager, link);
        return manager.PairsCount == 0 ? 0 :  1 - (binaryGeometricMean / Math.Pow(2, avG));
    }
}
