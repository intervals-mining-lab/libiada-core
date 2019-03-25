using LibiadaCore.Extensions;
using LibiadaCore.TimeSeries.Comparers;

namespace LibiadaCore.TimeSeries.Aligners
{
    public class ByShortestFromRightAligner : ITimeSeriesAligner
    {
        public (double[][] first, double[][] second) AlignSeries(double[] firstSeries, double[] secondSeries)
        {
            int shortestLength = firstSeries.SelectShortestLength(secondSeries);

            double[][] first = new double[1][];
            double[][] second = new double[1][];

            first[0] = firstSeries.SubArray(0, shortestLength);
            second[0] = secondSeries.SubArray(shortestLength - 1, secondSeries.Length);

            return (first, second);
        }
    }
}