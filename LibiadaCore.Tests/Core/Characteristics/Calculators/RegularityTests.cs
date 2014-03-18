namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The regularity test.
    /// </summary>
    [TestFixture]
    public class RegularityTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new Regularity();
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
        [TestCase(0, Link.None, 1.2248)]
        [TestCase(0, Link.Start, 1.5849)]
        [TestCase(0, Link.End, 1.4467)]
        [TestCase(0, Link.Both, 1.6956)]
        [TestCase(0, Link.Cycle, 1.8263)]
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
        [TestCase(0, Link.None, 0.7051)]
        [TestCase(0, Link.Start, 0.7203)]
        [TestCase(0, Link.End, 0.6866)]
        [TestCase(0, Link.Both, 0.70926)]
        [TestCase(0, Link.Cycle, 0.7917)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            this.ChainCharacteristicTest(index, link, value);
        }
    }
}