namespace LibiadaCore.Tests.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The identification information test.
    /// </summary>
    [TestFixture]
    public class IdentificationInformationTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new IdentificationInformation();
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
        [TestCase(0, Link.None, 0.5)]
        [TestCase(0, Link.Start, 0.5306)]
        [TestCase(0, Link.End, 0.5239)]
        [TestCase(0, Link.Both, 0.5307)]
        [TestCase(0, Link.Cycle, 0.5211)]
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
        [TestCase(0, Link.None, 1.5283)]
        [TestCase(0, Link.Start, 1.581)]
        [TestCase(0, Link.End, 1.5594)]
        [TestCase(0, Link.Both, 1.5785)]
        [TestCase(0, Link.Cycle, 1.571)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            this.ChainCharacteristicTest(index, link, value);
        }
    }
}