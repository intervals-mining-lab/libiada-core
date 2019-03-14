using System;
using System.Collections.Generic;
using LibiadaCore.Extensions;

namespace LibiadaCore.TimeSeries
{
    public class EuclideanTimeSeriesComparerByShortest: ITimeSeriesComparer
    {
        private EuclideanDistanceBetweenPointsCalculator calculator;

        private EuclideanTimeSeriesComparerByShortest(EuclideanDistanceBetweenPointsCalculator calculator)
        {
            this.calculator = calculator;
        }

        public List<double> GetDistance(double[] firstTimeSerie, double[] secondTimeSerie)
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

            return distances;
        }
    }
}