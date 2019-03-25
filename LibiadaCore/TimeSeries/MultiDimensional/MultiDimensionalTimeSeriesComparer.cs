using System;
using System.Collections.Generic;
using LibiadaCore.TimeSeries.Aggregators;
using LibiadaCore.TimeSeries.Comparers;
using LibiadaCore.TimeSeries.OneDimensional;

namespace LibiadaCore.TimeSeries.MultiDimensional
{
    public class MultiDimensionalTimeSeriesComparer: IMultiDimensionalTimeSeriesComparer
    {
        private ITimeSeriesAligner aligner;
        private IMultiDimensionalPointsDistance calculator;
        private IDistancesAggregator aggregator;

        private MultiDimensionalTimeSeriesComparer(ITimeSeriesAligner aligner, IMultiDimensionalPointsDistance calculator, IDistancesAggregator aggregator = null)
        {
            this.aligner = aligner;
            this.calculator = calculator;
            this.aggregator = aggregator ?? new Min();
        }

        public double GetDistance(double[][] firstTimeSerie, double[][] secondTimeSerie)
        {
            List<double> distances = new List<double>();

            for (int i = 0; i < firstTimeSerie.Length; i++)
            {
                distances.Add(calculator.GetDistance(firstTimeSerie[i], secondTimeSerie[i]));
            }

            return aggregator.Aggregate(distances);
        }
    }
}