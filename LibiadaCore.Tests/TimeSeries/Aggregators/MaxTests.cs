using System.Collections.Generic;
using LibiadaCore.TimeSeries.Aggregators;
using NUnit.Framework;

namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    [TestFixture]
    public class MaxTests
    {
        private static List<double> distances = new List<double>()
        {
            1,2,3,4,5
        };

        private double max = 5;

        [Test]
        public void MaxTest()
        {
            var agregator = new Max();
            double result = agregator.Aggregate(distances);
            Assert.AreEqual(result, max);
        }
    }
}