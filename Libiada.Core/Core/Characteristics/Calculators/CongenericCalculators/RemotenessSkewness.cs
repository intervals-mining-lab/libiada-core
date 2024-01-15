namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The remoteness skewness.
/// </summary>
public class RemotenessSkewness : ICongenericCalculator
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

        List<int> uniqueIntervals = intervals.Distinct().ToList();

        var intervalsCount = new IntervalsCount();
        var averageRemoteness = new AverageRemoteness();

        double result = 0;
        double gDeltaLog = averageRemoteness.Calculate(chain, link);
        double nj = intervalsCount.Calculate(chain, link);
        foreach (int interval in uniqueIntervals)
        {
            // number of intervals of certain length
            double nk = intervals.Count(i => i == interval);
            double centeredRemoteness = Math.Log(interval, 2) - gDeltaLog;
            result += centeredRemoteness * centeredRemoteness * centeredRemoteness * nk / nj;
        }

        return result;
    }
}
