namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The alphabetic depth test.
    /// </summary>
    [TestFixture]
    public class AlphabeticDepthTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Calculator = new AlphabeticDepth();
        }

        /// <summary>
        /// The alphabetic depth test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>

        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

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