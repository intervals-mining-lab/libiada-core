using System;
using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.TimeSeries.Aggregators
{
    public class SumModule : IDistancesAggregator
    {
        public double Aggregate(List<double> distances)
        {
            return Math.Abs(distances.Sum());
        }
    }
}