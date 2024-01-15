namespace LibiadaCore.Tests.TimeSeries.OneDimensional.DistanceCalculatorsTests
{
    using LibiadaCore.TimeSeries.OneDimensional.DistanceCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The Hamming distance between one dimensional points tests.
    /// </summary>
    [TestFixture]
    public class HammingDistanceBetweenOneDimensionalPointsTests
    {
        /// <summary>
        /// The Hamming distance between one dimensional points test.
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
        [TestCase(102.01, 1.3, 4)]
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