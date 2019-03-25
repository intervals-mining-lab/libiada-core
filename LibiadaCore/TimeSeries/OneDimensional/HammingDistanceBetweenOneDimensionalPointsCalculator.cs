namespace LibiadaCore.TimeSeries.OneDimensional
{
    public class HammingDistanceBetweenOneDimensionalPointsCalculator : IOneDimensionalPointsDistance
    {
        public double GetDistance(double firstPoint, double secondPoint)
        {
            string[] firstPointStringArray = firstPoint.ToString().Split(',');
            string[] secondPointStringArray = secondPoint.ToString().Split(',');

            string intPartFirst = firstPointStringArray[0];
            string intPartSecond = secondPointStringArray[0];

            if (firstPointStringArray[0].Length > secondPointStringArray[0].Length)
            {
                for (int i = 0; i < firstPointStringArray[0].Length - secondPointStringArray[0].Length; i++)
                {
                    intPartSecond = "0" + intPartSecond;
                }
            }
            else
            {
                for (int i = 0; i < secondPointStringArray[0].Length - firstPointStringArray[0].Length; i++)
                {
                    intPartFirst = "0" + intPartFirst;
                }
            }

            string fracPartFirst = firstPointStringArray[1];
            string fracPartSecond = secondPointStringArray[1];

            if (firstPointStringArray[1].Length > secondPointStringArray[1].Length)
            {
                fracPartFirst = firstPointStringArray[1].Substring(0, secondPointStringArray[1].Length);
            }
            else
            {
                fracPartSecond = secondPointStringArray[1].Substring(0, firstPointStringArray[1].Length);
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