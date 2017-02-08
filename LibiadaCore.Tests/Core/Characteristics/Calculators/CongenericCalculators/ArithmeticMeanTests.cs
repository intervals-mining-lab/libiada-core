namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The arithmetic mean test.
    /// </summary>
    [TestFixture]
    public class ArithmeticMeanTests : CongenericCalculatorsTests
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
        [TestCase(0, Link.None, 2)]
        [TestCase(0, Link.Start, 2.6667)]
        [TestCase(0, Link.End, 2.3333)]
        [TestCase(0, Link.Both, 2.75)]
        [TestCase(0, Link.Cycle, 3.3333)]

        [TestCase(1, Link.None, 2.6667)]
        [TestCase(1, Link.Start, 3)]
        [TestCase(1, Link.End, 3)]
        [TestCase(1, Link.Both, 3.2)]
        [TestCase(1, Link.Cycle, 3.75)]

        [TestCase(2, Link.None, 0)]
        [TestCase(2, Link.Start, 1)]
        [TestCase(2, Link.End, 1)]
        [TestCase(2, Link.Both, 1)]
        [TestCase(2, Link.Cycle, 1)]

        [TestCase(3, Link.None, 0)]
        [TestCase(3, Link.Start, 8)]
        [TestCase(3, Link.End, 1)]
        [TestCase(3, Link.Both, 4.5)]
        [TestCase(3, Link.Cycle, 8)]

        [TestCase(4, Link.None, 249950)]
        [TestCase(4, Link.Start, 166667)]
        [TestCase(4, Link.End, 333300)]
        [TestCase(4, Link.Both, 250000.25)]
        [TestCase(4, Link.Cycle, 333333.3333)]

        [TestCase(5, Link.None, 1)]
        [TestCase(5, Link.Start, 1)]
        [TestCase(5, Link.End, 1)]
        [TestCase(5, Link.Both, 1)]
        [TestCase(5, Link.Cycle, 1)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
