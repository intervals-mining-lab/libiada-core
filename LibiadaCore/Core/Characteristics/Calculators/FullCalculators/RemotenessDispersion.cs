﻿namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The remoteness dispersion.
    /// </summary>
    public class RemotenessDispersion : IFullCalculator
    {
        /// <summary>
        /// The intervals count.
        /// </summary>
        private readonly IFullCalculator intervalsCount = new IntervalsCount();

        /// <summary>
        /// The geometric mean.
        /// </summary>
        private readonly IFullCalculator geometricMean = new GeometricMean();

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Average remoteness dispersion <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            List<int> intervals = new List<int>();
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                intervals.AddRange(chain.CongenericChain(i).GetIntervals(link).ToList());
            }

            if (intervals.Count == 0)
            {
                return 0;
            }

            List<int> uniqueIntervals = intervals.Distinct().ToList();

            List<int> intervalsCounts = new List<int>();

            for (int i = 0; i < uniqueIntervals.Count; i++)
            {
                var currentInterval = uniqueIntervals[i];
                intervalsCounts.Add(intervals.Count(interval => interval == currentInterval));
            }

            double result = 0;
            double gDelta = geometricMean.Calculate(chain, link);
            int n = (int)intervalsCount.Calculate(chain, link);

            for (int i = 0; i < uniqueIntervals.Count; i++)
            {
                int nk = intervalsCounts[i];
                double kDelta = uniqueIntervals[i];
                double centeredRemoteness = Math.Log(kDelta, 2) - Math.Log(gDelta, 2);
                result += centeredRemoteness * centeredRemoteness * nk / n;
            }

            return result;
        }
    }
}
