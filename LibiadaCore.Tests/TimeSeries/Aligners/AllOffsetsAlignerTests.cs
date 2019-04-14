namespace LibiadaCore.Tests.TimeSeries.Aligners
{
    using LibiadaCore.TimeSeries.Aligners;

    using NUnit.Framework;

    /// <summary>
    /// The all offsets aligner tests.
    /// </summary>
    public class AllOffsetsAlignerTests
    {
        /// <summary>
        /// The combination tests.
        /// </summary>
        private static readonly object[][] CombinationTests =
            {
                new object[]
                {
                    new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4, 5 },
                    new[] { new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 } },
                    new[] { new double[] { 1, 2, 3 }, new double[] { 2, 3, 4 }, new double[] { 3, 4, 5 } }
                },
                new object[]
                {
                    new double[] { 1, 2, 3, 4, 5, 6 }, new double[] { 1, 2, 3 },
                    new[] { new double[] { 1, 2, 3 }, new double[] { 2, 3, 4 }, new double[] { 3, 4, 5 }, new double[] { 4, 5, 6 } },
                    new[] { new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 } }
                }
            };

        /// <summary>
        /// The all offsets align test.
        /// </summary>
        /// <param name="firstSeries">
        /// The first Series.
        /// </param>
        /// <param name="secondSeries">
        /// The second Series.
        /// </param>
        /// <param name="firstExpected">
        /// The first Expected.
        /// </param>
        /// <param name="secondExpected">
        /// The second Expected.
        /// </param>
        [TestCaseSource("CombinationTests")]

        public void AllOffsetsAlignTest(double[] firstSeries, double[] secondSeries, double[][] firstExpected, double[][] secondExpected)
        {
            var aligner = new AllOffsetsAligner();
            var result = aligner.AlignSeries(firstSeries, secondSeries);
            Assert.AreEqual(firstExpected, result.first);
            Assert.AreEqual(secondExpected, result.second);
        }
    }
}