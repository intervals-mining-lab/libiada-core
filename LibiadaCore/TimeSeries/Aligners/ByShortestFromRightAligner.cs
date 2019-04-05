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

            int startIndex = secondSeries.Length - firstSeries.Length;

            first[0] = firstSeries.SubArray(0, shortestLength);
            second[0] = secondSeries.SubArray(startIndex, secondSeries.Length - startIndex);

            return (first, second);
        }
    }
}