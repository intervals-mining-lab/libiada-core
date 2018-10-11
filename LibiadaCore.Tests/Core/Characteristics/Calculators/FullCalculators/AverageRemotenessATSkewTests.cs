namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessATSkewTests : FullCalculatorsTests<AverageRemotenessATSkew>
    {
        /// <summary>
        /// The calculation test.
        /// </summary>
        /// <param name="index">
        /// Full sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(1, Link.None, 0.3539)]
        [TestCase(1, Link.Start, 0.0234)]
        [TestCase(1, Link.End, 0.1556)]
        [TestCase(1, Link.Both, -0.0261)]
        [TestCase(1, Link.Cycle, 0.0811)]

        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }

        /// <summary>
        /// Sequence without Adenin or Timine calculation test.
        /// </summary>
        /// <param name="index">
        /// Full sequence index in <see cref="ChainsStorage"/>.
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
        /// Full sequence index in <see cref="ChainsStorage"/>.
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
