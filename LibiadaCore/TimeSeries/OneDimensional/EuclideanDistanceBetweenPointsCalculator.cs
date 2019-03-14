using System;

namespace LibiadaCore.TimeSeries
{
    public abstract class EuclideanDistanceBetweenPointsCalculator: IDistanceBetweenPoints
    {
        public double GetDistance(double firstPoint, double secondPoint)
        {
            return Math.Abs(firstPoint - secondPoint);
        }
    }
}