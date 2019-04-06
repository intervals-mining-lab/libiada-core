using System.Collections.Generic;
using LibiadaCore.TimeSeries.Aggregators;
using NUnit.Framework;

namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    [TestFixture]
    public class SumSquareRootTests
    {
        private static List<double> distances = new List<double>()
        {
            1,2,3,4,5,6,7,8
        };

        private double sumSqrt = 6;

        [Test]
        public void SumSquareRootTest()
        {
            var agregator = new SumSquareRoot();
            double result = agregator.Aggregate(distances);
            Assert.AreEqual(result, sumSqrt);
        }
    }
}