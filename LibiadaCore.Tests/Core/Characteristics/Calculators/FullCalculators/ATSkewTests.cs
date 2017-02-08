namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using System;

    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class ATSkewTests : FullCalculatorsTests
    {
        /// <summary>
        /// The calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(5, 0)]
        [TestCase(6, 0.6)]
        public void CalculationTest(int index, double value)
        {
            var links = (Link[])Enum.GetValues(typeof(Link));
            foreach (var link in links)
            {
                ChainCharacteristicTest(index, link, value);
            }
        }

        /// <summary>
        /// Sequence without Adenin or Timine calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(3, 0)]
        [TestCase(4, 0)]
        public void SequenceWithoutATTest(int index, double value)
        {
            var links = (Link[])Enum.GetValues(typeof(Link));
            foreach (var link in links)
            {
                ChainCharacteristicTest(index, link, value);
            }
        }
    }
}
