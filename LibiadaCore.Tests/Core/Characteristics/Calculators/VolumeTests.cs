namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The volume test.
    /// </summary>
    [TestFixture]
    public class VolumeTests : CalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("Volume");
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
        [TestCase(0, Link.None, 3)]
        [TestCase(0, Link.Start, 12)]
        [TestCase(0, Link.End, 9)]
        [TestCase(0, Link.Both, 36)]
        [TestCase(0, Link.Cycle, 18)]

        [TestCase(1, Link.None, 10)]
        [TestCase(1, Link.Start, 40)]
        [TestCase(1, Link.End, 40)]
        [TestCase(1, Link.Both, 160)]
        [TestCase(1, Link.Cycle, 70)]

        [TestCase(2, Link.None, 1)]
        [TestCase(2, Link.Start, 1)]
        [TestCase(2, Link.End, 1)]
        [TestCase(2, Link.Both, 1)]
        [TestCase(2, Link.Cycle, 1)]

        [TestCase(3, Link.None, 1)]
        [TestCase(3, Link.Start, 8)]
        [TestCase(3, Link.End, 1)]
        [TestCase(3, Link.Both, 8)]
        [TestCase(3, Link.Cycle, 8)]

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
        /// The calculation test.
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
        [TestCase(0, Link.None, 144)]
        [TestCase(0, Link.Start, 2160)]
        [TestCase(0, Link.End, 1152)]
        [TestCase(0, Link.Both, 17280)]
        [TestCase(0, Link.Cycle, 5184)]
        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
