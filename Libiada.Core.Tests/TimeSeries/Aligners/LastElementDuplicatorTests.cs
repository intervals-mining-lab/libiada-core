namespace Libiada.Core.Tests.TimeSeries.Aligners;

using Libiada.Core.TimeSeries.Aligners;

/// <summary>
/// The last element duplication aligner tests.
/// </summary>
public class LastElementDuplicatorTests
{
    /// <summary>
    /// The combination tests.
    /// </summary>
    private static readonly object[][] CombinationTests =
    [
        [new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6 }, new double[] { 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 }],
        [new double[] { 1, 2, 3, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6 }, new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 }]
    ];

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
    [TestCaseSource(nameof(CombinationTests))]

    public void LastElementDuplicationAlignerTest(double[] firstTimeSeries, double[] secondTimeSeries, double[] expected)
    {
        var aligner = new LastElementDuplicator();
        var (first, second) = aligner.AlignSeries(firstTimeSeries, secondTimeSeries);
        var actual = firstTimeSeries.Length < secondTimeSeries.Length ? first[0] : second[0];
        Assert.That(actual, Is.EqualTo(expected));
    }
}
