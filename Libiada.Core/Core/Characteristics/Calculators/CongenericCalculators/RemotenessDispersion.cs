namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using System;
using System.Collections.Generic;
using System.Linq;

using Libiada.Core.Extensions;

/// <summary>
/// The remoteness dispersion.
/// </summary>
public class RemotenessDispersion : ICongenericCalculator
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
        var intervals = chain.GetArrangement(link).ToList();

        if (intervals.Count == 0)
        {
            return 0;
        }

        var intervalsDictionary = intervals
                                 .GroupBy(i => i)
                                 .ToDictionary(i => i.Key, i => i.Count());

        var intervalsCount = new IntervalsCount();
        var averageRemoteness = new AverageRemoteness();

        double result = 0;
        double nj = intervalsCount.Calculate(chain, link);
        double gDeltaLog = averageRemoteness.Calculate(chain, link);
        foreach ((int interval, int nk) in intervalsDictionary)
        {
            double centeredRemoteness = Math.Log(interval, 2) - gDeltaLog;
            result += centeredRemoteness * centeredRemoteness * nk / nj;
        }

        return result;
    }
}
