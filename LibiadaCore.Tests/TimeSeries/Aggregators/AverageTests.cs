using System.Collections.Generic;

namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    using LibiadaCore.TimeSeries.Aggregators;

    using NUnit.Framework;

    [TestFixture]
    public class AverageTests
    {
        private static List<double> distances = new List<double>()
        {
            1,2,3,4,5
        };

        private double average = 3;

        [Test]
        public void AverageTest()
        {
            var aggregator = new Average();
            double result = aggregator.Aggregate(distances);
            Assert.AreEqual(result, average);
        }
    }
}