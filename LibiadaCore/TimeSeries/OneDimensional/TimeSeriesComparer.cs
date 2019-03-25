using System;
using System.Collections.Generic;
using System.Linq;
using LibiadaCore.Extensions;
using LibiadaCore.TimeSeries.Aggregators;
using LibiadaCore.TimeSeries.Comparers;

namespace LibiadaCore.TimeSeries.OneDimensional
{
    public class EuclideanTimeSeriesComparer: ITimeSeriesDistanceCalculator
    {
        private ITimeSeriesAligner aligner;
        private EuclideanDistanceBetweenOneDimensionalPointsCalculator calculator;
        private IDistancesAggregator aggregator;

        private EuclideanTimeSeriesComparer(ITimeSeriesAligner aligner, EuclideanDistanceBetweenOneDimensionalPointsCalculator calculator, IDistancesAggregator aggregator = null)
        {
            this.aligner = aligner;
            this.calculator = calculator;
            this.aggregator = aggregator ?? new Min();
        }

        public double GetDistance(double[] firstTimeSeries, double[] secondTimeSeries)
        {
            (double[][] first, double[][] second) = aligner.AlignSeries(firstTimeSeries, secondTimeSeries);

            double[] aggregated = new double[first.Length];

            for (int i = 0; i < first.Length; i++)
            {
                List<double> distances = new List<double>();
                for (int j = 0; j < first[0].Length; j++)
                {
                    distances.Add(calculator.GetDistance(first[i][j], second[i][j]));
                }

                aggregated[i] = aggregator.Aggregate(distances);
            }

            return aggregated.Min();
        }
    }
}