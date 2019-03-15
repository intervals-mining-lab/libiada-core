using System;

namespace LibiadaCore.TimeSeries
{
    public class HammingDistanceBetweenOneDimensionalPointsCalculator: IDistanceBetweenOneDimensionalPoints
    {
        public double GetDistance(double firstPoint, double secondPoint)
        {
            string[] fPoint = firstPoint.ToString().Split(',');
            string[] sPoint = secondPoint.ToString().Split(',');

            string intPartFirst = fPoint[0];
            string intPartSecond = sPoint[0];

            if (fPoint[0].Length > sPoint[0].Length)
            {
                for (int i = 0; i < Math.Abs(fPoint[0].Length - sPoint[0].Length); i++)
                {
                    intPartSecond = "0" + intPartSecond;
                }
            }
            else
            {
                for (int i = 0; i < Math.Abs(sPoint[0].Length - fPoint[0].Length); i++)
                {
                    intPartFirst = "0" + intPartFirst;
                }
            }

            string fracPartFirst = fPoint[1];
            string fracPartSecond = sPoint[1];

            if (fPoint[1].Length > sPoint[1].Length)
            {
                fracPartFirst = fPoint[1].Substring(0, sPoint[1].Length);
            }
            else
            {
                fracPartSecond = sPoint[1].Substring(0, fPoint[1].Length);
            }

            int distance = 0;

            for (int i = 0; i < intPartFirst.Length; i++)
            {
                if (intPartFirst[i] != intPartSecond[i])
                {
                    distance++;
                }
            }

            for (int i = 0; i < fracPartFirst.Length; i++)
            {
                if (fracPartFirst[i] != fracPartSecond[i])
                {
                    distance++;
                }
            }

            return distance;
        }
    }
}