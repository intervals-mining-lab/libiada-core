using LibiadaCore.Extensions;

namespace LibiadaCore.Tests.TimeSeries.Aligners
{
    using LibiadaCore.Core;
    using LibiadaCore.TimeSeries.Aligners;

    using NUnit.Framework;

    [TestFixture]
    public class ByShortestAlignerTests
    {
        private double[] shortTimeSeries = { 1.01, 2, 5, 17.3 };
        private double[] longTimeSeries = { 1.3, 2, 5, 17.4, 12, 23 };
        private double[] expectedSubArray = { 1.3, 2, 5, 17.4 };

        [Test]
        public void ShortestAlignTest()
        {
            var aligner = new ByShortestAligner();
            var result = aligner.AlignSeries(shortTimeSeries, longTimeSeries);
            Assert.AreEqual(result.first[0].Length, result.second[0].Length);
            Assert.AreEqual(result.first[0], shortTimeSeries);
            Assert.AreEqual(result.second[0], expectedSubArray);
        }
    }
}