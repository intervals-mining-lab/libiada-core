using System;
using LibiadaCore.Extensions;

namespace LibiadaCore.Tests.TimeSeries.Aligners
{
    using LibiadaCore.Core;
    using LibiadaCore.TimeSeries.Aligners;

    using NUnit.Framework;

    [TestFixture]
    public class ByShortestFromRightAlignerTests
    {
        private double[] shortTimeSeries = { 1.01, 2, 5, 17.3 };
        private double[] longTimeSeries = { 1.3, 2, 5, 17.4, 12, 23 };
        double[] expectedSubArray = { 5, 17.4, 12, 23 };

        [Test]
        public void ShortestFromRightAlignTest()
        {
            var aligner = new ByShortestFromRightAligner();
            var result = aligner.AlignSeries(shortTimeSeries, longTimeSeries);
            Assert.AreEqual(result.first[0].Length, result.second[0].Length);
            Assert.AreEqual(result.first[0], shortTimeSeries);
            Assert.AreEqual(result.second[0], expectedSubArray);
        }
    }
}