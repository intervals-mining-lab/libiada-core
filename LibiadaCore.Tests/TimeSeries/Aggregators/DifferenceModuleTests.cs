using System.Collections.Generic;
using LibiadaCore.TimeSeries.Aggregators;
using NUnit.Framework;

namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    [TestFixture]
    public class DifferenceModuleTests
    {
        private static List<double> distances = new List<double>()
        {
            1,2,3,4,5
        };

        private double diffMod = 13;

        [Test]
        public void DifferenceModuleTest()
        {
            var agregator = new DifferenceModule();
            double result = agregator.Aggregate(distances);
            Assert.AreEqual(result, diffMod);
        }
    }
}