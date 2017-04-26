using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The intervals sum test.
    /// </summary>
    [TestFixture]
    public class IntervalsSumTests : CongenericCalculatorsTests<IntervalsSum>
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
        [TestCase(0, Link.None, 4)]
        [TestCase(0, Link.Start, 8)]
        [TestCase(0, Link.End, 7)]
        [TestCase(0, Link.Both, 11)]
        [TestCase(0, Link.Cycle, 10)]

        [TestCase(1, Link.None, 8)]
        [TestCase(1, Link.Start, 12)]
        [TestCase(1, Link.End, 12)]
        [TestCase(1, Link.Both, 16)]
        [TestCase(1, Link.Cycle, 15)]

        [TestCase(2, Link.None, 0)]
        [TestCase(2, Link.Start, 1)]
        [TestCase(2, Link.End, 1)]
        [TestCase(2, Link.Both, 2)]
        [TestCase(2, Link.Cycle, 1)]

        [TestCase(3, Link.None, 0)]
        [TestCase(3, Link.Start, 8)]
        [TestCase(3, Link.End, 1)]
        [TestCase(3, Link.Both, 9)]
        [TestCase(3, Link.Cycle, 8)]

        [TestCase(4, Link.None, 499900)]
        [TestCase(4, Link.Start, 500001)]
        [TestCase(4, Link.End, 999900)]
        [TestCase(4, Link.Both, 1000001)]
        [TestCase(4, Link.Cycle, 1000000)]

        [TestCase(5, Link.None, 4)]
        [TestCase(5, Link.Start, 5)]
        [TestCase(5, Link.End, 5)]
        [TestCase(5, Link.Both, 6)]
        [TestCase(5, Link.Cycle, 5)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
