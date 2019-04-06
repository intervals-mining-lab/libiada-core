using System.Collections.Generic;
using LibiadaCore.TimeSeries.Aggregators;
using NUnit.Framework;

namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    [TestFixture]
    public class DifferenceSquareRootTests
    {
        private static List<double> distances = new List<double>()
        {
            1,2,3,4,5,6,7,8,9,10,11
        };

        private double diffSqrt = 8;

        [Test]
        public void DifferenceSquareRootTest()
        {
            var agregator = new DifferenceSquareRoot();
            double result = agregator.Aggregate(distances);
            Assert.AreEqual(result, diffSqrt);
        }
    }
}