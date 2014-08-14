namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The alphabetic depth test.
    /// </summary>
    [TestFixture]
    public class AlphabeticDepthTests : FullCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("AlphabeticDepth");
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
        [TestCase(0, Link.None, 4.5237)]
        [TestCase(0, Link.Start, 6.9887)]
        [TestCase(0, Link.End, 6.4165)]
        [TestCase(0, Link.Both, 8.8815)]
        [TestCase(0, Link.Cycle, 7.7856)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        }
    }
}