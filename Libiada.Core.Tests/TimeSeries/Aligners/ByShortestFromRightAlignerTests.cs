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
        (double[][] firstResult, double[][] secondResult) = aligner.AlignSeries(shortTimeSeries, longTimeSeries);

        Assert.Multiple(() =>
        {
            Assert.That(firstResult[0], Is.EqualTo(shortTimeSeries));
            Assert.That(secondResult[0], Is.EqualTo(second));
        });
    }
}
