using System;
using System.Collections.Generic;
using LibiadaCore.Extensions;
using LibiadaCore.TimeSeries.Aggregators;

namespace LibiadaCore.TimeSeries
{
    public class HammingTimeSeriesComparerByShortest: ITimeSeriesComparer
    {
        private HammingDistanceBetweenOneDimensionalPointsCalculator calculator;
        private IDistancesAggregator aggregator;

        private HammingTimeSeriesComparerByShortest(HammingDistanceBetweenOneDimensionalPointsCalculator calculator, IDistancesAggregator aggregator = null)
        {
            this.calculator = calculator;
            this.aggregator = aggregator ?? new Min();
        }

        public double GetDistance(double[] firstTimeSerie, double[] secondTimeSerie)
        {
            if (firstTimeSerie.Length == secondTimeSerie.Length)
            {
                throw new Exception();
            }

            int shortestLength = firstTimeSerie.SelectShortestLength(secondTimeSerie);

            List<double> distances = new List<double>();

            for (int i = 0; i < shortestLength; i++)
            {
                distances.Add(calculator.GetDistance(firstTimeSerie[i], secondTimeSerie[i]));
            }

            return aggregator.Aggregate(distances);
        }
    }
}