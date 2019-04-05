using System;

namespace LibiadaCore.TimeSeries.OneDimensional
{
    public class EuclideanDistanceBetweenOneDimensionalPointsCalculator : IOneDimensionalPointsDistance
    {
        public double GetDistance(double firstPoint, double secondPoint)
        {
            return Math.Abs(firstPoint - secondPoint);
        }
    }
}