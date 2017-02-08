namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class DepthTests : CongenericCalculatorsTests
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
        [TestCase(0, Link.None, 1.585)]
        [TestCase(0, Link.Start, 3.585)]
        [TestCase(0, Link.End, 3.1699)]
        [TestCase(0, Link.Both, 5.1699)]
        [TestCase(0, Link.Cycle, 4.1699)]

        [TestCase(1, Link.None, 3.3219)]
        [TestCase(1, Link.Start, 5.3219)]
        [TestCase(1, Link.End, 5.3219)]
        [TestCase(1, Link.Both, 7.3219)]
        [TestCase(1, Link.Cycle, 6.1293)]

        [TestCase(2, Link.None, 0)]
        [TestCase(2, Link.Start, 0)]
        [TestCase(2, Link.End, 0)]
        [TestCase(2, Link.Both, 0)]
        [TestCase(2, Link.Cycle, 0)]

        [TestCase(3, Link.None, 0)]
        [TestCase(3, Link.Start, 3)]
        [TestCase(3, Link.End, 0)]
        [TestCase(3, Link.Both, 3)]
        [TestCase(3, Link.Cycle, 3)]

        [TestCase(5, Link.None, 0)]
        [TestCase(5, Link.Start, 0)]
        [TestCase(5, Link.End, 0)]
        [TestCase(5, Link.Both, 0)]
        [TestCase(5, Link.Cycle, 0)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
