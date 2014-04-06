namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The intervals count test.
    /// </summary>
    [TestFixture]
    public class IntervalsCountTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new IntervalsCount();
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
        [TestCase(0, Link.None, 2)]
        [TestCase(0, Link.Start, 3)]
        [TestCase(0, Link.End, 3)]
        [TestCase(0, Link.Both, 4)]
        [TestCase(0, Link.Cycle, 3)]

        [TestCase(1, Link.None, 3)]
        [TestCase(1, Link.Start, 4)]
        [TestCase(1, Link.End, 4)]
        [TestCase(1, Link.Both, 5)]
        [TestCase(1, Link.Cycle, 4)]

        [TestCase(2, Link.None, 0)]
        [TestCase(2, Link.Start, 1)]
        [TestCase(2, Link.End, 1)]
        [TestCase(2, Link.Both, 2)]
        [TestCase(2, Link.Cycle, 1)]

        [TestCase(3, Link.None, 0)]
        [TestCase(3, Link.Start, 1)]
        [TestCase(3, Link.End, 1)]
        [TestCase(3, Link.Both, 2)]
        [TestCase(3, Link.Cycle, 1)]

        [TestCase(4, Link.None, 2)]
        [TestCase(4, Link.Start, 3)]
        [TestCase(4, Link.End, 3)]
        [TestCase(4, Link.Both, 4)]
        [TestCase(4, Link.Cycle, 3)]

        [TestCase(5, Link.None, 4)]
        [TestCase(5, Link.Start, 5)]
        [TestCase(5, Link.End, 5)]
        [TestCase(5, Link.Both, 6)]
        [TestCase(5, Link.Cycle, 5)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            this.CongenericChainCharacteristicTest(index, link, value);
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
        [TestCase(0, Link.None, 7)]
        [TestCase(0, Link.Start, 10)]
        [TestCase(0, Link.End, 10)]
        [TestCase(0, Link.Both, 13)]
        [TestCase(0, Link.Cycle, 10)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            this.ChainCharacteristicTest(index, link, value);
        }
    }
}