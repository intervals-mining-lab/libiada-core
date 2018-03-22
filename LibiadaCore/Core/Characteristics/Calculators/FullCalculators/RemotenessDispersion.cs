namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Extensions;

    /// <summary>
    /// The remoteness dispersion.
    /// </summary>
    public class RemotenessDispersion : IFullCalculator
    {
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
            var intervals = new List<int>();
            Alphabet alphabet = chain.Alphabet;
            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                intervals.AddRange(chain.CongenericChain(i).GetArrangement(link).ToList());
            }

            if (intervals.Count == 0)
            {
                return 0;
            }

            var intervalsDictionary = intervals
                                     .GroupBy(i => i)
                                     .ToDictionary(i => i.Key, i => i.Count());

            var intervalsCount = new IntervalsCount();
            var geometricMean = new GeometricMean();

            double result = 0;
            double gDelta = geometricMean.Calculate(chain, link);
            double n = intervalsCount.Calculate(chain, link);

            foreach ((int interval, int count) in intervalsDictionary)
            {
                double centeredRemoteness = Math.Log(interval, 2) - Math.Log(gDelta, 2);
                result += centeredRemoteness * centeredRemoteness * count / n;
            }

            return result;
        }
    }
}
