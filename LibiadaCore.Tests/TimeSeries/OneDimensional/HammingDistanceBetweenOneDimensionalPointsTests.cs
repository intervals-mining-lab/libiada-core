namespace LibiadaCore.Tests.TimeSeries.OneDimensional
{
    using LibiadaCore.TimeSeries.OneDimensional;

    using NUnit.Framework;

    [TestFixture]
    public class HammingDistanceBetweenOneDimensionalPointsTests
    {
        [TestCase(102.01, 1.3, 3)]
        [TestCase(10.01, 1.31, 3)]
        [TestCase(1.1, 1.3, 1)]
        [TestCase(9999.9999, 8888.8888, 8)]
        [TestCase(999.9999, 8888.8888, 8)]
        public void HammingDistanceTest(double firstPoint, double secondPoint, int expectedDistance)
        {
            var calculator = new HammingDistanceBetweenOneDimensionalPointsCalculator();
            double result = calculator.GetDistance(firstPoint, secondPoint);
            Assert.AreEqual(result, expectedDistance);
        }
    }
}