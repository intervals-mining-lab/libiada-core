namespace Libiada.Core.TimeSeries.Aggregators;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The sum module aggregator.
/// </summary>
public class SumModule : IDistancesAggregator
{
    /// <summary>
    /// The aggregate.
    /// </summary>
    /// <param name="distances">
    /// The distances.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Aggregate(List<double> distances)
    {
        return Math.Abs(distances.Sum());
    }
}