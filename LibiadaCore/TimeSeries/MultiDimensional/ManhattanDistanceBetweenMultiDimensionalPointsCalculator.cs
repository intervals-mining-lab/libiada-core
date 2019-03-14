using System;

namespace LibiadaCore.TimeSeries.MultiDimensional
{
    public class ManhattanDistanceBetweenMultiDimensionalPointsCalculator: IDistanceBetweenMultiDimensionalPoints
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
                distance += Math.Abs(firstPoint[i] - secondPoint[i]);
            }

            return distance;
        }
    }
}