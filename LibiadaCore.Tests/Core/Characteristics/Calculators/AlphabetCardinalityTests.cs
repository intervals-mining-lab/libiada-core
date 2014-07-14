namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The alphabet cardinality test.
    /// </summary>
    [TestFixture]
    public class AlphabetCardinalityTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Calculator = new AlphabetCardinality();
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
        [TestCase(0, Link.None, 1)]
        [TestCase(0, Link.Start, 1)]
        [TestCase(0, Link.End, 1)]
        [TestCase(0, Link.Both, 1)]
        [TestCase(0, Link.Cycle, 1)]

        [TestCase(1, Link.None, 1)]
        [TestCase(1, Link.Start, 1)]
        [TestCase(1, Link.End, 1)]
        [TestCase(1, Link.Both, 1)]
        [TestCase(1, Link.Cycle, 1)]

        [TestCase(2, Link.None, 1)]
        [TestCase(2, Link.Start, 1)]
        [TestCase(2, Link.End, 1)]
        [TestCase(2, Link.Both, 1)]
        [TestCase(2, Link.Cycle, 1)]

        [TestCase(3, Link.None, 1)]
        [TestCase(3, Link.Start, 1)]
        [TestCase(3, Link.End, 1)]
        [TestCase(3, Link.Both, 1)]
        [TestCase(3, Link.Cycle, 1)]

        [TestCase(4, Link.None, 1)]
        [TestCase(4, Link.Start, 1)]
        [TestCase(4, Link.End, 1)]
        [TestCase(4, Link.Both, 1)]
        [TestCase(4, Link.Cycle, 1)]

        [TestCase(5, Link.None, 1)]
        [TestCase(5, Link.Start, 1)]
        [TestCase(5, Link.End, 1)]
        [TestCase(5, Link.Both, 1)]
        [TestCase(5, Link.Cycle, 1)]
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
        [TestCase(0, Link.None, 3)]
        [TestCase(0, Link.Start, 3)]
        [TestCase(0, Link.End, 3)]
        [TestCase(0, Link.Both, 3)]
        [TestCase(0, Link.Cycle, 3)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}