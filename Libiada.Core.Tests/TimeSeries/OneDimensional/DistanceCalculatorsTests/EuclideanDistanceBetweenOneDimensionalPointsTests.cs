namespace Libiada.Core.Tests.TimeSeries.OneDimensional.DistanceCalculatorsTests;

using Libiada.Core.TimeSeries.OneDimensional.DistanceCalculators;

/// <summary>
/// The euclidean distance between one dimensional points tests.
/// </summary>
[TestFixture]
public class EuclideanDistanceBetweenOneDimensionalPointsTests
{
    /// <summary>
    /// The euclidean distance between one dimensional points test.
    /// </summary>
    /// <param name="firstPoint">
    /// The first point.
    /// </param>
    /// <param name="secondPoint">
    /// The second point.
    /// </param>
    /// <param name="expectedDistance">
    /// The expected distance.
    /// </param>
    [TestCase(1.01, 1.3, 1.3 - 1.01)]
    [TestCase(1.98765, 1.98765, 0)]
    [TestCase(1.12345, 1.98765, 1.98765 - 1.12345)]

    public void EuclideanDistanceTest(double firstPoint, double secondPoint, double expectedDistance)
    {
        var calculator = new EuclideanDistanceBetweenOneDimensionalPointsCalculator();
        double result = calculator.GetDistance(firstPoint, secondPoint);
        Assert.AreEqual(result, expectedDistance);
    }
}