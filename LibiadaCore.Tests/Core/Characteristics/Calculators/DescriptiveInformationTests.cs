namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The descriptive information test.
    /// </summary>
    [TestFixture]
    public class DescriptiveInformationTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new DescriptiveInformation();
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
        [TestCase(0, Link.None, 1.4142)]
        [TestCase(0, Link.Start, 1.4445)]
        [TestCase(0, Link.End, 1.4378)]
        [TestCase(0, Link.Both, 1.4446)]
        [TestCase(0, Link.Cycle, 1.435)]
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
        [TestCase(0, Link.None, 2.8845)]
        [TestCase(0, Link.Start, 2.9917)]
        [TestCase(0, Link.End, 2.9473)]
        [TestCase(0, Link.Both, 2.9865)]
        [TestCase(0, Link.Cycle, 2.971)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            this.ChainCharacteristicTest(index, link, value);
        }
    }
}