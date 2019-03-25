using System;
using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.TimeSeries.Aggregators
{
    public class SumSquareRoot : IDistancesAggregator
    {
        public double Aggregate(List<double> distances)
        {
            return Math.Sqrt(distances.Sum());
        }
    }
}