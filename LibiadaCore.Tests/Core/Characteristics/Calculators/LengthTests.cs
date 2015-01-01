namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The length test.
    /// </summary>
    [TestFixture]
    public class LengthTests : CalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("Length");
        }

        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, Link.None, 10)]
        [TestCase(0, Link.Start, 10)]
        [TestCase(0, Link.End, 10)]
        [TestCase(0, Link.Both, 10)]
        [TestCase(0, Link.Cycle, 10)]

        [TestCase(1, Link.None, 15)]
        [TestCase(1, Link.Start, 15)]
        [TestCase(1, Link.End, 15)]
        [TestCase(1, Link.Both, 15)]
        [TestCase(1, Link.Cycle, 15)]

        [TestCase(2, Link.None, 1)]
        [TestCase(2, Link.Start, 1)]
        [TestCase(2, Link.End, 1)]
        [TestCase(2, Link.Both, 1)]
        [TestCase(2, Link.Cycle, 1)]

        [TestCase(3, Link.None, 8)]
        [TestCase(3, Link.Start, 8)]
        [TestCase(3, Link.End, 8)]
        [TestCase(3, Link.Both, 8)]
        [TestCase(3, Link.Cycle, 8)]

        [TestCase(4, Link.None, 1000000)]
        [TestCase(4, Link.Start, 1000000)]
        [TestCase(4, Link.End, 1000000)]
        [TestCase(4, Link.Both, 1000000)]
        [TestCase(4, Link.Cycle, 1000000)]

        [TestCase(5, Link.None, 5)]
        [TestCase(5, Link.Start, 5)]
        [TestCase(5, Link.End, 5)]
        [TestCase(5, Link.Both, 5)]
        [TestCase(5, Link.Cycle, 5)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        /// <summary>
        /// The chain calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, Link.None, 10)]
        [TestCase(0, Link.Start, 10)]
        [TestCase(0, Link.End, 10)]
        [TestCase(0, Link.Both, 10)]
        [TestCase(0, Link.Cycle, 10)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
