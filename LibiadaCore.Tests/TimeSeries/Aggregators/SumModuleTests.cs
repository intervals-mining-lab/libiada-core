using System.Collections.Generic;
using LibiadaCore.TimeSeries.Aggregators;
using NUnit.Framework;

namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    [TestFixture]
    public class SumModuleTests
    {
        private static List<double> distances = new List<double>()
        {
            1,2,3,4,5
        };

        private double sumMod = 15;

        [Test]
        public void SumModuleTest()
        {
            var agregator = new SumModule();
            double result = agregator.Aggregate(distances);
            Assert.AreEqual(result, sumMod);
        }
    }
}