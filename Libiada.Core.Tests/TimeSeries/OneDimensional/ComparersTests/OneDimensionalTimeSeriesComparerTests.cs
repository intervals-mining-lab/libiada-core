namespace Libiada.Core.Tests.TimeSeries.OneDimensional.ComparersTests;

using Libiada.Core.TimeSeries.Aggregators;
using Libiada.Core.TimeSeries.Aligners;
using Libiada.Core.TimeSeries.OneDimensional.Comparers;
using Libiada.Core.TimeSeries.OneDimensional.DistanceCalculators;

/// <summary>
/// The one dimensional time series comparer tests.
/// </summary>
[TestFixture]
public class OneDimensionalTimeSeriesComparerTests
{
    /// <summary>
    /// The combination_tests sources.
    /// </summary>
    private static readonly object[][] CombinationTests =
    [

        // ByShortestAligner tests with Euclidean distance calculator
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Average()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceSquareRoot()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Max(),
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Min()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new SumModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new SumSquareRoot()
        ],

        // ByShortestAligner tests with Hamming distance calculator
        [
            new double[] { -1, -2, -3, -4, -5 }, new double[] { 1, 2, 3, 4, 5 }, 1,
            new ByShortestAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Average()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceSquareRoot()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new[] { 1.12345, 2.12345, 3.12345, 4.12345, 5.123456 }, 6,
            new ByShortestAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Max()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Min()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new SumModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new SumSquareRoot()
        ],

        // ByShortestFromRightAligner tests with Euclidean distance calculator
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 2, 3, 4, 5, 6 }, 1,
            new ByShortestFromRightAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Average()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceSquareRoot()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Max()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Min()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new SumModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new SumSquareRoot()
        ],

        // ByShortestFromRightAligner tests with Hamming distance calculator
        [
            new double[] { 1, 2, 3, 4, 5 }, new[] { 1.01234, 2.01234, 3.01234, 4.01234, 5.01234 }, 4,
            new ByShortestFromRightAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Average()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceSquareRoot()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Max()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Min()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new SumModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new ByShortestFromRightAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new SumSquareRoot()
        ],

        // AllOffsetsAligner tests with Euclidean distance calculator
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Average()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceSquareRoot()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Max()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new Min()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new SumModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new EuclideanDistanceBetweenOneDimensionalPointsCalculator(),
            new SumSquareRoot()
        ],

        // AllOffsetsAligner tests with Hamming distance calculator
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Average()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new DifferenceSquareRoot()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Max()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new Min()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new SumModule()
        ],
        [
            new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, 0,
            new AllOffsetsAligner(),
            new HammingDistanceBetweenOneDimensionalPointsCalculator(),
            new SumSquareRoot()
        ]
    ];

    /// <summary>
    /// The time series compare generalized test.
    /// </summary>
    /// <param name="firstSeries">
    /// The first series.
    /// </param>
    /// <param name="secondSeries">
    /// The second series.
    /// </param>
    /// <param name="expected">
    /// The expected.
    /// </param>
    /// <param name="aligner">
    /// The aligner.
    /// </param>
    /// <param name="calculator">
    /// The calculator.
    /// </param>
    /// <param name="aggregator">
    /// The aggregator.
    /// </param>
    [TestCaseSource(nameof(CombinationTests))]

    public void CompareTest(
        double[] firstSeries,
        double[] secondSeries,
        double expected,
        ITimeSeriesAligner aligner,
        IOneDimensionalPointsDistance calculator,
        IDistancesAggregator aggregator)
    {
        OneDimensionalTimeSeriesComparer comparer = new(aligner, calculator, aggregator);
        double result = comparer.GetDistance(firstSeries, secondSeries);
        Assert.That(result, Is.EqualTo(expected));
    }
}
