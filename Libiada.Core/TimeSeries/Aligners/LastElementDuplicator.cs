namespace Libiada.Core.TimeSeries.Aligners;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The last element duplication aligner.
/// </summary>
public class LastElementDuplicator : ITimeSeriesAligner
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
    /// The <see cref="(double[][] first, double[][] second)"/>.
    /// </returns>
    public (double[][] first, double[][] second) AlignSeries(double[] firstSeries, double[] secondSeries)
    {

        double[][] first = new double[1][];
        double[][] second = new double[1][];
        List<double> result = new List<double>();

        if (firstSeries.Length < secondSeries.Length)
        {
            for (int i = 0; i < firstSeries.Length; i++)
            {
                result.Add(firstSeries[i]);
            }

            for (int i = firstSeries.Length; i < secondSeries.Length; i++)
            {
                result.Add(firstSeries.Last());
            }

            first[0] = result.ToArray();
            second[0] = secondSeries;
        }
        else
        {
            for (int i = 0; i < secondSeries.Length; i++)
            {
                result.Add(secondSeries[i]);
            }

            for (int i = secondSeries.Length; i < firstSeries.Length; i++)
            {
                result.Add(secondSeries.Last());
            }

            first[0] = firstSeries;
            second[0] = result.ToArray();
        }

        return (first, second);
    }
}