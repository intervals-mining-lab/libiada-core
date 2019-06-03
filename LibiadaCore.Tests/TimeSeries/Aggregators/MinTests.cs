namespace LibiadaCore.Tests.TimeSeries.Aggregators
{
    using System.Collections.Generic;

    using LibiadaCore.TimeSeries.Aggregators;

    using NUnit.Framework;

    /// <summary>
    /// The min aggregator tests.
    /// </summary>
    [TestFixture]
    public class MinTests
    {
        /// <summary>
        /// The distances list.
        /// </summary>
        private static readonly List<double> distances = new List<double>()
        {
            1, 2, 3, 4, 5
        };

        /// <summary>
        /// The expected min value.
        /// </summary>
        private const double min = 1;

        /// <summary>
        /// The min aggregator test.
        /// </summary>
        [Test]
        public void MinTest()
        {
            var aggregator = new Min();
            double result = aggregator.Aggregate(distances);
            Assert.AreEqual(min, result);
        }
    }
}