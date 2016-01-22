namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The descriptive information test.
    /// </summary>
    [TestFixture]
    public class DescriptiveInformationTests : CalculatorsTests
    {
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

        [TestCase(1, Link.None, 1.4445)]
        [TestCase(1, Link.Start, 1.4422)]
        [TestCase(1, Link.End, 1.4422)]
        [TestCase(1, Link.Both, 1.4383)]
        [TestCase(1, Link.Cycle, 1.4226)]

        [TestCase(2, Link.None, 1)]
        [TestCase(2, Link.Start, 1)]
        [TestCase(2, Link.End, 1)]
        [TestCase(2, Link.Both, 1)]
        [TestCase(2, Link.Cycle, 1)]

        [TestCase(3, Link.None, 1)]
        [TestCase(3, Link.Start, 1.2968)]
        [TestCase(3, Link.End, 1)]
        [TestCase(3, Link.Both, 1.3969)]
        [TestCase(3, Link.Cycle, 1.2968)]

        [TestCase(4, Link.None, 1)]
        [TestCase(4, Link.Start, 1.0001)]
        [TestCase(4, Link.End, 1)]
        [TestCase(4, Link.Both, 1)]
        [TestCase(4, Link.Cycle, 1)]

        [TestCase(5, Link.None, 1)]
        [TestCase(5, Link.Start, 1)]
        [TestCase(5, Link.End, 1)]
        [TestCase(5, Link.Both, 1)]
        [TestCase(5, Link.Cycle, 1)]
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
        [TestCase(0, Link.None, 2.8845)]
        [TestCase(0, Link.Start, 2.9917)]
        [TestCase(0, Link.End, 2.9473)]
        [TestCase(0, Link.Both, 2.9865)]
        [TestCase(0, Link.Cycle, 2.971)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
