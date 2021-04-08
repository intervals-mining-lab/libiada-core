namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The remoteness kurtosis.
    /// </summary>
    public class RemotenessKurtosis : ICongenericCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in sequence.
        /// </param>
        /// <returns>
        /// Average remoteness dispersion <see cref="double"/> value.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var intervals = new List<int>();
            intervals.AddRange(chain.GetArrangement(link).ToList());
            

            if (intervals.Count == 0)
            {
                return 0;
            }

            List<int> uniqueIntervals = intervals.Distinct().ToList();

            var intervalsCount = new IntervalsCount();
            var geometricMean = new GeometricMean();

            double result = 0;
            double gDelta = geometricMean.Calculate(chain, link);
            double gDeltaLog = Math.Log(gDelta, 2);
            double nj = intervalsCount.Calculate(chain, link);
            foreach (int interval in uniqueIntervals)
            {
                // number of intervals of certain length
                double nk = intervals.Count(i => i == interval);
                double centeredRemoteness = Math.Log(interval, 2) - gDeltaLog;
                result += centeredRemoteness * centeredRemoteness * centeredRemoteness * centeredRemoteness * nk / nj;
            }

            return result;
        }
    }
}
