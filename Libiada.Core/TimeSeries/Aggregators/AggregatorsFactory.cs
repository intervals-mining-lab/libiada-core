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
        switch (aggregator)
        {
            case Aggregator.Average:
                return new Average();
            case Aggregator.DifferenceModule:
                return new DifferenceModule();
            case Aggregator.DifferenceSquareRoot:
                return new DifferenceSquareRoot();
            case Aggregator.Max:
                return new Max();
            case Aggregator.Min:
                return new Min();
            case Aggregator.SumModule:
                return new SumModule();
            case Aggregator.SumSquareRoot:
                return new SumSquareRoot();
            default:
                throw new InvalidEnumArgumentException(nameof(aggregator), (int)aggregator, typeof(Aggregator));
        }
    }
}