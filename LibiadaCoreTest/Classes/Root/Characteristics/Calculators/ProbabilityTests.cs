namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The probability test.
    /// </summary>
    [TestFixture]
    public class ProbabilityTests : AbstractCalculatorTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Calculator = new Probability();
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
        [TestCase(0, Link.None, 0.3)]
        [TestCase(0, Link.Start, 0.3)]
        [TestCase(0, Link.End, 0.3)]
        [TestCase(0, Link.Both, 0.3)]
        [TestCase(0, Link.Cycle, 0.3)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
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
        [TestCase(0, Link.None, 1)]
        [TestCase(0, Link.Start, 1)]
        [TestCase(0, Link.End, 1)]
        [TestCase(0, Link.Both, 1)]
        [TestCase(0, Link.Cycle, 1)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}