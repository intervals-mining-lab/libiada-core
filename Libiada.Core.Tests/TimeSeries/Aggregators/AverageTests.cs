namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    using System.Collections.Generic;

    using LibiadaCore.TimeSeries.Aggregators;

    using NUnit.Framework;

    /// <summary>
    /// The average aggregator tests.
    /// </summary>
    [TestFixture]
    public class AverageTests
    {
        /// <summary>
        /// The distances list.
        /// </summary>
        private static readonly List<double> distances = new List<double>()
        {
            1, 2, 3, 4, 5
        };

        /// <summary>
        /// The expected average result.
        /// </summary>
        private const double average = 3;

        /// <summary>
        /// The average aggregator test.
        /// </summary>
        [Test]
        public void AverageTest()
        {
            var aggregator = new Average();
            double result = aggregator.Aggregate(distances);
            Assert.AreEqual(average, result);
        }
    }
}