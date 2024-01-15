namespace Libiada.Core.Tests.TimeSeries.Aligners;

using System;
using System.Diagnostics;

using Libiada.Core.TimeSeries.Aligners;

using NUnit.Framework;

/// <summary>
/// The last element duplication aligner tests.
/// </summary>
public class LastElementDuplicatorTests
{
    /// <summary>
    /// The combination tests.
    /// </summary>
    private static readonly object[][] CombinationTests =
    {
        new object[] { new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6 }, new double[] { 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 } },
        new object[] { new double[] { 1, 2, 3, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6 }, new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 } }
    };

    /// <summary>
    /// The last element duplication aligner test.
    /// </summary>
    /// <param name="firstTimeSeries">
    /// The first time series.
    /// </param>
    /// <param name="secondTimeSeries">
    /// The second time series.
    /// </param>
    /// <param name="expected">
    /// The expected.
    /// </param>
    [TestCaseSource("CombinationTests")]

    public void LastElementDuplicationAlignerTest(double[] firstTimeSeries, double[] secondTimeSeries, double[] expected)
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        var aligner = new LastElementDuplicator();
        var result = aligner.AlignSeries(firstTimeSeries, secondTimeSeries);
        timer.Stop();
        Console.WriteLine("Time elapsed: (ms) : {0}", timer.Elapsed.TotalMilliseconds);
        Assert.AreEqual(
            expected,
            firstTimeSeries.Length < secondTimeSeries.Length ? result.first[0] : result.second[0]);
    }
}