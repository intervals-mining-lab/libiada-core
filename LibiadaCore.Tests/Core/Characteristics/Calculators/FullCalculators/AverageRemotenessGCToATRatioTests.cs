using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessGCToATRatioTests : FullCalculatorsTests<AverageRemotenessGCToATRatio>
    {

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
        [TestCase(1, Link.None, 2.0906)]
        [TestCase(1, Link.Start, 1.9527)]
        [TestCase(1, Link.End, 1.0826)]
        [TestCase(1, Link.Both, 1.2505)]
        [TestCase(1, Link.Cycle, 1.4932)]

        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }

        /// <summary>
        /// Sequence without Adenin or Timine calculation test.
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
        [TestCase(3, Link.None, 0)]
        [TestCase(3, Link.Start, 0)]
        [TestCase(3, Link.End, 0)]
        [TestCase(3, Link.Both, 0)]
        [TestCase(3, Link.Cycle, 0)]

        [TestCase(4, Link.None, 0)]
        [TestCase(4, Link.Start, 0)]
        [TestCase(4, Link.End, 0)]
        [TestCase(4, Link.Both, 0)]
        [TestCase(4, Link.Cycle, 0)]
        public void SequenceWithoutATTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }

        /// <summary>
        /// No intervals test.
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
        [TestCase(5, Link.None, 0)]
        [TestCase(7, Link.None, 0)]
        public void NoIntervalsTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
