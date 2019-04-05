namespace LibiadaCore.Tests.TimeSeries.OneDimensional
{
    using LibiadaCore.Core;
    using LibiadaCore.TimeSeries.OneDimensional;

    using NUnit.Framework;

    public class HammingDistanceBetweenOneDimensionalPointsTests
    {
        private double firstPoint = 102.01;
        private double secondPoint = 1.3;
        private double expectedDistance = 3;

        [Test]
        public void HammingDistanceTest()
        {
            var calculator = new HammingDistanceBetweenOneDimensionalPointsCalculator();
            double result = calculator.GetDistance(firstPoint, secondPoint);
            Assert.AreEqual(result, expectedDistance);
        }
    }
}