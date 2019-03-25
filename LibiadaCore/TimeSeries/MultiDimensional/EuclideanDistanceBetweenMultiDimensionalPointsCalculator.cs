using System;

namespace LibiadaCore.TimeSeries.MultiDimensional
{
    public class EuclideanDistanceBetweenMultiDimensionalPointsCalculator : IMultiDimensionalPointsDistance
    {
        public double GetDistance(double[] firstPoint, double[] secondPoint)
        {
            if (firstPoint.Length != secondPoint.Length)
            {
                throw new Exception();
            }

            double distance = 0;

            for (int i = 0; i < firstPoint.Length; i++)
            {
                distance += Math.Pow((firstPoint[i] - secondPoint[i]), 2);
            }

            return Math.Sqrt(distance);
        }
    }
}