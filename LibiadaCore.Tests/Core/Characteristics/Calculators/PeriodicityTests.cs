namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The periodicity test.
    /// </summary>
    [TestFixture]
    public class PeriodicityTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new Periodicity();
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
        [TestCase(0, Link.None, 0.8661)]
        [TestCase(0, Link.Start, 0.8585)]
        [TestCase(0, Link.End, 0.8915)]
        [TestCase(0, Link.Both, 0.8907)]
        [TestCase(0, Link.Cycle, 0.7862)]
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
        [TestCase(0, Link.None, 0.8375)]
        [TestCase(0, Link.Start, 0.8288)]
        [TestCase(0, Link.End, 0.8432)]
        [TestCase(0, Link.Both, 0.8344)]
        [TestCase(0, Link.Cycle, 0.7841)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            this.ChainCharacteristicTest(index, link, value);
        }
    }
}