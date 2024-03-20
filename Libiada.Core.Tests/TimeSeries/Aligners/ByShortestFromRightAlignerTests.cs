namespace Libiada.Core.Tests.TimeSeries.Aligners;

using Libiada.Core.TimeSeries.Aligners;

/// <summary>
/// The by shortest from right aligner tests.
/// </summary>
[TestFixture]
public class ByShortestFromRightAlignerTests
{
    /// <summary>
    /// The shortest time series.
    /// </summary>
    private readonly double[] shortTimeSeries = [1, 2, 3];

    /// <summary>
    /// The longest time series.
    /// </summary>
    private readonly double[] longTimeSeries = [1, 2, 3, 4, 5];

    /// <summary>
    /// The first.
    /// </summary>
    private readonly double[] first = [1, 2, 3];

    /// <summary>
    /// The expected sub array.
    /// </summary>
    private readonly double[] second = [3, 4, 5];

    /// <summary>
    /// The shortest from right align test.
    /// </summary>
    [Test]
    public void ShortestFromRightAlignTest()
    {
        ByShortestFromRightAligner aligner = new();
        (double[][] first, double[][] second) result = aligner.AlignSeries(shortTimeSeries, longTimeSeries);

        Assert.That(result.first[0], Is.EqualTo(shortTimeSeries));
        Assert.That(result.second[0], Is.EqualTo(second));
    }
}
