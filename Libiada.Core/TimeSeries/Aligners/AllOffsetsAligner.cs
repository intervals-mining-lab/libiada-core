namespace Libiada.Core.TimeSeries.Aligners;

using System;

using Libiada.Core.Extensions;

/// <summary>
/// The cycle aligner.
/// </summary>
public class AllOffsetsAligner : ITimeSeriesAligner
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
        int startIndex = 0;

        if (firstSeries.Length < secondSeries.Length)
        {
            double[][] first = new double[secondSeries.Length - firstSeries.Length + 1][];
            double[][] second = new double[secondSeries.Length - firstSeries.Length + 1][];

            for (int i = 0; i < secondSeries.Length - firstSeries.Length + 1; i++)
            {
                first[i] = firstSeries;
                second[i] = secondSeries.SubArray(startIndex, shortestLength);
                startIndex++;
            }

            return (first, second);
        }
        else
        {
            double[][] first = new double[firstSeries.Length - secondSeries.Length + 1][];
            double[][] second = new double[firstSeries.Length - secondSeries.Length + 1][];

            for (int i = 0; i < firstSeries.Length - secondSeries.Length + 1; i++)
            {
                first[i] = firstSeries.SubArray(startIndex, shortestLength);
                second[i] = secondSeries;
                startIndex++;
            }

            return (first, second);
        }
    }
}