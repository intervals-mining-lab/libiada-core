namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Redundancy of binary chain.
    /// </summary>
    public class Redundancy : BinaryCalculator
    {
        //TODO: refactor to using of intervals manager

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
        /// Redundancy.
        /// </returns>
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            if (manager.FirstElement.Equals(manager.SecondElement))
            {
                return 0;
            }

            var firstElementCount = manager.FirstChain.OccurrencesCount;
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

            avG = manager.PairsCount == 0 ? 0 : avG / manager.PairsCount;

            var geometricMeanCalculator = new GeometricMean();
            double binaryGeometricMean = geometricMeanCalculator.Calculate(manager, link);

            return 1 - (binaryGeometricMean / Math.Pow(2, avG));
        }
    }
}