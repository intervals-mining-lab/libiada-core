namespace LibiadaCore.TimeSeries.Aligners
{
    using System;

    using LibiadaCore.Extensions;

    /// <summary>
    /// The by shortest from right aligner.
    /// </summary>
    public class ByShortestFromRightAligner : ITimeSeriesAligner
    {
        /// <summary>
        /// The align series.
        /// </summary>
        /// <param name="firstSeries">
        /// The first series.
        /// </param>
        /// <param name="secondSeries">
        /// The second series.
        /// </param>
        /// <returns>
        /// The <see T:cref="(double[][] first, double[][] second)"/>.
        /// </returns>
        public (double[][] first, double[][] second) AlignSeries(double[] firstSeries, double[] secondSeries)
        {
            int shortestLength = firstSeries.SelectShortestLength(secondSeries);

            double[][] first = new double[1][];
            double[][] second = new double[1][];

            int startIndex = Math.Abs(secondSeries.Length - firstSeries.Length);

            first[0] = firstSeries.SubArray(0, shortestLength);
            second[0] = secondSeries.SubArray(startIndex, secondSeries.Length - startIndex);

            return (first, second);
        }
    }
}