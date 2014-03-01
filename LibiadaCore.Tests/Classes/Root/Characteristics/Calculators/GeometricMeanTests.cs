namespace LibiadaCore.Tests.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The geometric mean test.
    /// </summary>
    [TestFixture]
    public class GeometricMeanTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new GeometricMean();
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
        [TestCase(0, Link.None, 1.7321)]
        [TestCase(0, Link.Start, 2.2894)]
        [TestCase(0, Link.End, 2.0801)]
        [TestCase(0, Link.Both, 2.4495)]
        [TestCase(0, Link.Cycle, 2.6207)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            this.CongenericChainCharacteristicTest(0, link, value);
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
        [TestCase(0, Link.None, 2.0339)]
        [TestCase(0, Link.Start, 2.155)]
        [TestCase(0, Link.End, 2.0237)]
        [TestCase(0, Link.Both, 2.1182)]
        [TestCase(0, Link.Cycle, 2.3522)]
        public void CalculationTest(int index, Link link, double value)
        {
            this.ChainCharacteristicTest(0, link, value);
        }
    }
}