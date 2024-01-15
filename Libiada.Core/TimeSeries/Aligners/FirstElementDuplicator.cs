namespace Libiada.Core.TimeSeries.Aligners;

using System;
using System.Collections.Generic;

/// <summary>
/// The first element duplication aligner.
/// </summary>
public class FirstElementDuplicator : ITimeSeriesAligner
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

        int length = Math.Abs(firstSeries.Length - secondSeries.Length);
        double[] firstElems = new double[length];

        if (firstSeries.Length < secondSeries.Length)
        {
            List<double> result = new List<double>(secondSeries.Length);

            for (int i = 0; i < length; i++)
            {
                firstElems[i] = firstSeries[0];
            }

            result.AddRange(firstElems);
            result.AddRange(firstSeries);

            first[0] = result.ToArray();
            second[0] = secondSeries;
        }
        else
        {
            List<double> result = new List<double>(firstSeries.Length);

            for (int i = 0; i < length; i++)
            {
                firstElems[i] = secondSeries[0];
            }

            result.AddRange(firstElems);
            result.AddRange(secondSeries);

            first[0] = firstSeries;
            second[0] = result.ToArray();

        }

        return (first, second);
    }
}