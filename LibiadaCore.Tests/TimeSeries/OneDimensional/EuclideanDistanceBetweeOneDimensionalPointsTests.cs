namespace LibiadaCore.Tests.TimeSeries.OneDimensional
{
    using LibiadaCore.TimeSeries.OneDimensional;

    using NUnit.Framework;

    [TestFixture]
    public class EuclideanDistanceBetweeOneDimensionalPointsTests
    {
        [TestCase(1.01, 1.3, 1.3-1.01)]
        [TestCase(1.98765, 1.98765, 0)]
        [TestCase(1.12345, 1.98765, 1.98765 - 1.12345)]
        public void EuclideanDistanceTest(double firstPoint, double secondPoint, double expectedDistance)
        {
            var calculator = new EuclideanDistanceBetweenOneDimensionalPointsCalculator();
            double result = calculator.GetDistance(firstPoint, secondPoint);
            Assert.AreEqual(result, expectedDistance);
        }
    }
}