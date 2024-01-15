namespace Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The sum square root aggregator.
/// </summary>
public class SumSquareRoot : IDistancesAggregator
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
        return Math.Sqrt(Math.Abs(distances.Sum()));
    }
}