namespace Libiada.Core.Tests.TimeSeries.Aligners;

using Libiada.Core.TimeSeries.Aligners;

/// <summary>
/// The by shortest aligner tests.
/// </summary>
[TestFixture]
public class ByShortestAlignerTests
{
    /// <summary>
    /// The short time series.
    /// </summary>
    private readonly double[] shortTimeSeries = [1.01, 2, 5, 17.3];

    /// <summary>
    /// The long time series.
    /// </summary>
    private readonly double[] longTimeSeries = [1.3, 2, 5, 17.4, 12, 23];

    /// <summary>
    /// The expected sub array.
    /// </summary>
    private readonly double[] expectedSubArray = [1.3, 2, 5, 17.4];

    /// <summary>
    /// The shortest align test.
    /// </summary>
    [Test]
    public void ShortestAlignTest()
    {
        var aligner = new ByShortestAligner();
        var result = aligner.AlignSeries(shortTimeSeries, longTimeSeries);
        Assert.That(result.second[0], Has.Length.EqualTo(result.first[0].Length));
        Assert.That(result.first[0], Is.EqualTo(shortTimeSeries));
        Assert.That(result.second[0], Is.EqualTo(expectedSubArray));
    }
}
