namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class ATSkewTests : FullCalculatorsTests
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
        [TestCase(1, Link.None, 0)]
        [TestCase(1, Link.Start, 0)]
        [TestCase(1, Link.End, 0)]
        [TestCase(1, Link.Both, 0)]
        [TestCase(1, Link.Cycle, 0)]

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
    }
}
