namespace Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The DistancesAggregator interface.
/// </summary>
public interface IDistancesAggregator
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
    double Aggregate(List<double> distances);
}