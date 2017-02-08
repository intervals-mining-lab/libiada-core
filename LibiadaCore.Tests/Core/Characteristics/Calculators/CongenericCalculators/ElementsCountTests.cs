namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The elements count test.
    /// </summary>
    [TestFixture]
    public class ElementsCountTests : CongenericCalculatorsTests
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
        [TestCase(0, Link.None, 3)]
        [TestCase(0, Link.Start, 3)]
        [TestCase(0, Link.End, 3)]
        [TestCase(0, Link.Both, 3)]
        [TestCase(0, Link.Cycle, 3)]

        [TestCase(1, Link.None, 3)]
        [TestCase(1, Link.Start, 3)]
        [TestCase(1, Link.End, 3)]
        [TestCase(1, Link.Both, 3)]
        [TestCase(1, Link.Cycle, 3)]

        [TestCase(2, Link.None, 3)]
        [TestCase(2, Link.Start, 3)]
        [TestCase(2, Link.End, 3)]
        [TestCase(2, Link.Both, 3)]
        [TestCase(2, Link.Cycle, 3)]

        [TestCase(3, Link.None, 3)]
        [TestCase(3, Link.Start, 3)]
        [TestCase(3, Link.End, 3)]
        [TestCase(3, Link.Both, 3)]
        [TestCase(3, Link.Cycle, 3)]

        [TestCase(4, Link.None, 3)]
        [TestCase(4, Link.Start, 3)]
        [TestCase(4, Link.End, 3)]
        [TestCase(4, Link.Both, 3)]
        [TestCase(4, Link.Cycle, 3)]

        [TestCase(5, Link.None, 3)]
        [TestCase(5, Link.Start, 3)]
        [TestCase(5, Link.End, 3)]
        [TestCase(5, Link.Both, 3)]
        [TestCase(5, Link.Cycle, 3)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(0, link, value);
        }
    }
}
