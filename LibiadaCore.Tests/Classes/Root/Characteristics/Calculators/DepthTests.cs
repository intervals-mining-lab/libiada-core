namespace LibiadaCore.Tests.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class DepthTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new Depth();
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
        [TestCase(0, Link.None, 1.585)]
        [TestCase(0, Link.Start, 3.585)]
        [TestCase(0, Link.End, 3.1699)]
        [TestCase(0, Link.Both, 5.1699)]
        [TestCase(0, Link.Cycle, 4.1699)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            this.CongenericChainCharacteristicTest(index, link, value);
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
        [TestCase(0, Link.None, 7.1699)]
        [TestCase(0, Link.Start, 11.0768)]
        [TestCase(0, Link.End, 10.1699)]
        [TestCase(0, Link.Both, 14.0768)]
        [TestCase(0, Link.Cycle, 12.3399)]
        public void CalculationTest(int index, Link link, double value)
        {
            this.ChainCharacteristicTest(index, link, value);
        }
    }
}