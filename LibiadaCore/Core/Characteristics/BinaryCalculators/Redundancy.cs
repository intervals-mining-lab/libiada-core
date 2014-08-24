namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Redundancy of binary chain.
    /// </summary>
    public class Redundancy : BinaryCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="manager">
        /// Intervals manager.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Среднегеометрический интервал
        /// </returns>
        public override double Calculate(RelationIntervalsManager manager, Link link)
        {
            if (manager.firstElement.Equals(manager.secondElement))
            {
                return 0;
            }

            var count = new ElementsCount();
            var firstElementCount = (int)count.Calculate(manager.firstChain, link);
            double avG = 0;
            int currentEntrance = 0;

            for (int i = 1; i <= firstElementCount; i++)
            {
                if (manager.GetBinaryInterval(i) > 0)
                {
                    if (currentEntrance == 0)
                    {
                        currentEntrance = manager.GetAfter(manager.GetFirst(i));
                        if (link == Link.Start || link == Link.Both)
                        {
                            avG += Math.Log(currentEntrance, 2);
                        }
                    }
                    else
                    {
                        int nextEntrance = manager.GetAfter(manager.GetFirst(i));
                        avG += Math.Log(nextEntrance - currentEntrance, 2);
                        currentEntrance = nextEntrance;
                    }
                }
            }

            if (link == Link.End || link == Link.Both)
            {
                avG += Math.Log(manager.Length - currentEntrance, 2);
            }

            int pairs = manager.pairsCount;
            avG = pairs == 0 ? 0 : avG / pairs;
            var geometricMeanCalculator = new BinaryGeometricMean();
            double binaryGeometricMean = geometricMeanCalculator.Calculate(manager, link);
            return 1 - (binaryGeometricMean / Math.Pow(2, avG));
        }
    }
}