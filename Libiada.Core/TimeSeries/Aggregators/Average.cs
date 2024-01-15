namespace Libiada.Core.TimeSeries.Aggregators;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The average aggregator.
/// </summary>
public class Average : IDistancesAggregator
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
        return distances.Average();
    }
}