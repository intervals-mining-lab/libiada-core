namespace Libiada.Core.Tests.TimeSeries.Aligners;

using Libiada.Core.TimeSeries.Aligners;

using NUnit.Framework;

/// <summary>
/// The by shortest aligner tests.
/// </summary>
[TestFixture]
public class ByShortestAlignerTests
{
    /// <summary>
    /// The short time series.
    /// </summary>
    private readonly double[] shortTimeSeries = { 1.01, 2, 5, 17.3 };

    /// <summary>
    /// The long time series.
    /// </summary>
    private readonly double[] longTimeSeries = { 1.3, 2, 5, 17.4, 12, 23 };

    /// <summary>
    /// The expected sub array.
    /// </summary>
    private readonly double[] expectedSubArray = { 1.3, 2, 5, 17.4 };

    /// <summary>
    /// The shortest align test.
    /// </summary>
    [Test]
    public void ShortestAlignTest()
    {
        var aligner = new ByShortestAligner();
        var result = aligner.AlignSeries(shortTimeSeries, longTimeSeries);
        Assert.AreEqual(result.first[0].Length, result.second[0].Length);
        Assert.AreEqual(shortTimeSeries, result.first[0]);
        Assert.AreEqual(expectedSubArray, result.second[0]);
    }
}