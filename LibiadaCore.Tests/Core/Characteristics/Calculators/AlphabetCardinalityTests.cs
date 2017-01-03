namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System;

    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The alphabet cardinality test.
    /// </summary>
    [TestFixture]
    public class AlphabetCardinalityTests : FullCalculatorsTests
    {
        /// <summary>
        /// The chain calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, 3)]
        [TestCase(1, 4)]
        [TestCase(2, 4)]
        [TestCase(3, 2)]
        [TestCase(4, 1)]
        [TestCase(5, 4)]
        public void ChainCalculationTest(int index, double value)
        {
            var links = (Link[])Enum.GetValues(typeof(Link));
            foreach (var link in links)
            {
                ChainCharacteristicTest(index, link, value);
            }
        }
    }
}
