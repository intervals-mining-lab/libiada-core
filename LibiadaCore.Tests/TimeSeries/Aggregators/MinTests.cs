using System.Collections.Generic;
using LibiadaCore.TimeSeries.Aggregators;
using NUnit.Framework;

namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    [TestFixture]
    public class MinTests
    {
        private static List<double> distances = new List<double>()
        {
            1,2,3,4,5
        };

        private double min = 1;

        [Test]
        public void MinTest()
        {
            var agregator = new Min();
            double result = agregator.Aggregate(distances);
            Assert.AreEqual(result, min);
        }
    }
}