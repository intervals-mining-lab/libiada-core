using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessGCSkewTests : FullCalculatorsTests<AverageRemotenessGCSkew>
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
        [TestCase(1, Link.None, -0.0946)]
        [TestCase(1, Link.Start, 0.0989)]
        [TestCase(1, Link.End, -0.2423)]
        [TestCase(1, Link.Both, -0.0172)]
        [TestCase(1, Link.Cycle, 0.0278)]

        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }

        /// <summary>
        /// Sequence without Guanine or Cytozine calculation test.
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
        [TestCase(7, Link.None, 0)]
        [TestCase(7, Link.Start, 0)]
        [TestCase(7, Link.End, 0)]
        [TestCase(7, Link.Both, 0)]
        [TestCase(7, Link.Cycle, 0)]

        [TestCase(8, Link.None, 0)]
        [TestCase(8, Link.Start, 0)]
        [TestCase(8, Link.End, 0)]
        [TestCase(8, Link.Both, 0)]
        [TestCase(8, Link.Cycle, 0)]
        public void SequenceWithoutGCTest(int index, Link link, double value)
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
        [TestCase(3, Link.None, 0)]
        [TestCase(5, Link.None, 0)]
        public void NoIntervalsTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
