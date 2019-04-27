namespace LibiadaCore.Tests.TimeSeries.Aligners
{
    using LibiadaCore.TimeSeries.Aligners;

    using NUnit.Framework;

    /// <summary>
    /// The by shortest from right aligner tests.
    /// </summary>
    [TestFixture]
    public class ByShortestFromRightAlignerTests
    {
        /// <summary>
        /// The shortest time series.
        /// </summary>
        private readonly double[] shortTimeSeries = { 1.01, 2, 5, 17.3 };

        /// <summary>
        /// The longest time series.
        /// </summary>
        private readonly double[] longTimeSeries = { 1.3, 2, 5, 17.4, 12, 23 };

        /// <summary>
        /// The expected sub array.
        /// </summary>
        private readonly double[] expectedSubArray = { 5, 17.4, 12, 23 };

        /// <summary>
        /// The shortest from right align test.
        /// </summary>
        [Test]
        public void ShortestFromRightAlignTest()
        {
            var aligner = new ByShortestFromRightAligner();
            var result = aligner.AlignSeries(shortTimeSeries, longTimeSeries);
            Assert.AreEqual(result.first[0].Length, result.second[0].Length);
            Assert.AreEqual(shortTimeSeries, result.first[0]);
            Assert.AreEqual(expectedSubArray, result.second[0]);
        }
    }
}