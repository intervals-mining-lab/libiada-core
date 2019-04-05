using System;

namespace LibiadaCore.Tests.TimeSeries.OneDimensional
{
    using LibiadaCore.Core;
    using LibiadaCore.TimeSeries.OneDimensional;

    using NUnit.Framework;

    [TestFixture]
    public class EuclideanDistanceBetweeOneDimensionalPointsTests
    {
        private double firstPoint = 1.01;
        private double secondPoint = 1.3;
        private double expectedDistance = 1.3 - 1.01;

        [Test]
        public void EuclideanDistanceTest()
        {
            var calculator = new EuclideanDistanceBetweenOneDimensionalPointsCalculator();
            double result = calculator.GetDistance(firstPoint, secondPoint);
            Assert.AreEqual(result, expectedDistance);
        }
    }
}