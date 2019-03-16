using System;
using System.Collections.Generic;
using LibiadaCore.TimeSeries.Aggregators;

namespace LibiadaCore.TimeSeries.MultiDimensional
{
    public class EuclideanTimeSeriesComparer: IMultiDimensionalTimeSeriesComparer
    {
        private EuclideanDistanceBetweenMultiDimensionalPointsCalculator calculator;
        private IDistancesAggregator aggregator;

        private EuclideanTimeSeriesComparer(EuclideanDistanceBetweenMultiDimensionalPointsCalculator calculator, IDistancesAggregator aggregator = null)
        {
            this.calculator = calculator;
            this.aggregator = aggregator ?? new Min();
        }

        public double GetDistance(double[][] firstTimeSerie, double[][] secondTimeSerie)
        {
            if (firstTimeSerie.Length != secondTimeSerie.Length)
            {
                throw new Exception();
            }

            List<double> distances = new List<double>();

            for (int i = 0; i < firstTimeSerie.Length; i++)
            {
                distances.Add(calculator.GetDistance(firstTimeSerie[i], secondTimeSerie[i]));
            }

            return aggregator.Aggregate(distances);
        }
    }
}