namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The arithmetic mean test.
    /// </summary>
    [TestFixture]
    public class ArithmeticMeanTest : AbstractCalculatorTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArithmeticMeanTest"/> class.
        /// </summary>
        public ArithmeticMeanTest()
        {
            this.Calculator = new ArithmeticMean();
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
        [TestCase(0, Link.None, 2)]
        [TestCase(0, Link.Start, 2.6667)]
        [TestCase(0, Link.End, 2.3333)]
        [TestCase(0, Link.Both, 2.75)]
        [TestCase(0, Link.Cycle, 3.3333)]
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
        [TestCase(0, Link.None, 2.4286)]
        [TestCase(0, Link.Start, 2.6)]
        [TestCase(0, Link.End, 2.4)]
        [TestCase(0, Link.Both, 2.5385)]
        [TestCase(0, Link.Cycle, 3)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        }
    }
}