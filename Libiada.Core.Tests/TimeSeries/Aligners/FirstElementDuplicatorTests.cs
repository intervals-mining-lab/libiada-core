namespace Libiada.Core.Tests.TimeSeries.Aligners;

using Libiada.Core.TimeSeries.Aligners;


/// <summary>
/// The first element duplication aligner tests.
/// </summary>
public class FirstElementDuplicatorTests
{

    /// <summary>
    /// The combination tests.
    /// </summary>
    private static readonly object[][] CombinationTests =
    [
        [new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6 }, new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3 }],
        [new double[] { 1, 2, 3, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6, 4, 5, 6 }, new double[] { 1, 2, 3 }, new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3 }]
    ];

    /// <summary>
    /// The first element duplication aligner test.
    /// </summary>
    /// <param name="firstTimeSeries">
    /// The first Time Series.
    /// </param>
    /// <param name="secondTimeSeries">
    /// The second Time Series.
    /// </param>
    /// <param name="expected">
    /// The expected.
    /// </param>
    [TestCaseSource(nameof(CombinationTests))]

    public void FirstElementDuplicationAlignerTest(double[] firstTimeSeries, double[] secondTimeSeries, double[] expected)
    {
        var aligner = new FirstElementDuplicator();
        var (first, second) = aligner.AlignSeries(firstTimeSeries, secondTimeSeries);
        var actual = firstTimeSeries.Length < secondTimeSeries.Length ? first[0] : second[0];
        Assert.That(actual, Is.EqualTo(expected));
    }
}
