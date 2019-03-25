using System;
using System.Collections.Generic;

namespace LibiadaCore.TimeSeries.Aggregators
{
    public class DifferenceModule : IDistancesAggregator
    {
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
}