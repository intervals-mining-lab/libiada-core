﻿namespace Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The min aggregator.
/// </summary>
public class Min : IDistancesAggregator
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
        return distances.Min();
    }
}
