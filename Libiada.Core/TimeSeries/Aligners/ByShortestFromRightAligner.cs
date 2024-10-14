namespace Libiada.Core.TimeSeries.Aligners;

using Libiada.Core.Extensions;

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

        double[][] first = new double[1][];
        double[][] second = new double[1][];

        int startIndex = Math.Abs(firstSeries.Length - secondSeries.Length);

        if (firstSeries.Length < secondSeries.Length)
        {
            first[0] = firstSeries;
            second[0] = secondSeries.SubArray(startIndex, secondSeries.Length - startIndex);
        }
        else
        {
            first[0] = firstSeries.SubArray(startIndex, firstSeries.Length - startIndex);
            second[0] = secondSeries;
        }

        return (first, second);
    }
}
