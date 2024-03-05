namespace Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The difference module aggregator.
/// </summary>
public class DifferenceModule : IDistancesAggregator
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
        double distance = distances[0];
        for (int i = 1; i < distances.Count; i++)
        {
            distance -= distances[i];
        }
        return Math.Abs(distance);
    }
}