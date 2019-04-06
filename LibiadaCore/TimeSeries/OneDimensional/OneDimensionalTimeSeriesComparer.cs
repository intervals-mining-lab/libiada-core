using System.Collections.Generic;
using System.Linq;
using LibiadaCore.TimeSeries.Aggregators;
using LibiadaCore.TimeSeries.Aligners;

namespace LibiadaCore.TimeSeries.OneDimensional
{
    public class OneDimensionalTimeSeriesComparer : IOneDimensionalTimeSeriesComparer
    {
        private ITimeSeriesAligner aligner;
        private IOneDimensionalPointsDistance calculator;
        private IDistancesAggregator aggregator;

        public OneDimensionalTimeSeriesComparer(ITimeSeriesAligner aligner, IOneDimensionalPointsDistance calculator, IDistancesAggregator aggregator = null)
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