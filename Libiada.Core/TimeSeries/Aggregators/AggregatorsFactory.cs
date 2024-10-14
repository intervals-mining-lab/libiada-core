namespace Libiada.Core.TimeSeries.Aggregators;

using System.ComponentModel;

/// <summary>
/// The aggregators factory.
/// </summary>
public class AggregatorsFactory
{
    /// <summary>
    /// The get aligner.
    /// </summary>
    /// <param name="aggregator">
    /// The aggregator.
    /// </param>
    /// <returns>
    /// The <see cref="IDistancesAggregator"/>.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// </exception>
    public IDistancesAggregator GetAggregator(Aggregator aggregator)
    {
        return aggregator switch
        {
            Aggregator.Average => new Average(),
            Aggregator.DifferenceModule => new DifferenceModule(),
            Aggregator.DifferenceSquareRoot => new DifferenceSquareRoot(),
            Aggregator.Max => new Max(),
            Aggregator.Min => new Min(),
            Aggregator.SumModule => new SumModule(),
            Aggregator.SumSquareRoot => new SumSquareRoot(),
            _ => throw new InvalidEnumArgumentException(nameof(aggregator), (int)aggregator, typeof(Aggregator)),
        };
    }
}
