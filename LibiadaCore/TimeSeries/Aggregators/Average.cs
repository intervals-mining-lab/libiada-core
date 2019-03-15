using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.TimeSeries.Aggregators
{
    public class Average: IDistancesAggregator
    {
        public double Aggregate(List<double> distances)
        {
            return distances.Average();
        }
    }
}