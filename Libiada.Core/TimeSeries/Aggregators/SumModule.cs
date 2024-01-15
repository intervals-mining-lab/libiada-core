namespace Libiada.Core.TimeSeries.Aggregators;

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