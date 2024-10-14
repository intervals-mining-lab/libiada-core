namespace Libiada.Core.Tests.TimeSeries.Aligners;

using Libiada.Core.TimeSeries.Aligners;

/// <summary>
/// The all offsets aligner tests.
/// </summary>
public class AllOffsetsAlignerTests
{
    /// <summary>
    /// The combination tests.
    /// </summary>
    private static readonly object[][] CombinationTests =
        [
            [
                new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4, 5 },
                new[] { new double[] { 1, 2, 3 }, [1, 2, 3], [1, 2, 3] },
                new[] { new double[] { 1, 2, 3 }, [2, 3, 4], [3, 4, 5] }
            ],
            [
                new double[] { 1, 2, 3, 4, 5, 6 }, new double[] { 1, 2, 3 },
                new[] { new double[] { 1, 2, 3 }, [2, 3, 4], [3, 4, 5], [4, 5, 6] },
                new[] { new double[] { 1, 2, 3 }, [1, 2, 3], [1, 2, 3], [1, 2, 3] }
            ]
        ];

    /// <summary>
    /// The all offsets align test.
    /// </summary>
    /// <param name="firstSeries">
    /// The first Series.
    /// </param>
    /// <param name="secondSeries">
    /// The second Series.
    /// </param>
    /// <param name="firstExpected">
    /// The first Expected.
    /// </param>
    /// <param name="secondExpected">
    /// The second Expected.
    /// </param>
    [TestCaseSource(nameof(CombinationTests))]

    public void AllOffsetsAlignTest(double[] firstSeries, double[] secondSeries, double[][] firstExpected, double[][] secondExpected)
    {
        AllOffsetsAligner aligner = new();
        (double[][] first, double[][] second) = aligner.AlignSeries(firstSeries, secondSeries);
        Assert.Multiple(() =>
        {
            Assert.That(first, Is.EqualTo(firstExpected));
            Assert.That(second, Is.EqualTo(secondExpected));
        });
    }
}
