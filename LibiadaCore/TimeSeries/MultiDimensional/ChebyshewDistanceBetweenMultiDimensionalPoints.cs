using System;
using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.TimeSeries.MultiDimensional
{
    public class ChebyshewDistanceBetweenMultiDimensionalPoints: IDistanceBetweenMultiDimensionalPoints
    {
        public double GetDistance(double[] firstPoint, double[] secondPoint)
        {
            if (firstPoint.Length != secondPoint.Length)
            {
                throw new Exception();
            }

            List<double> distance = new List<double>();

            for (int i = 0; i < firstPoint.Length; i++)
            {
                distance.Add(Math.Abs(firstPoint[i] - secondPoint[i]));
            }

            return distance.Max();
        }
    }
}