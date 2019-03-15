using System.Collections.Generic;

namespace LibiadaCore.TimeSeries.Aggregators
{
    public interface IDistancesAggregator
    {
        double Aggregate(List<double> distances);
    }
}