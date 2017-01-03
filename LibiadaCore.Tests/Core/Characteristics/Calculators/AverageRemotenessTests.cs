namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The average remoteness test.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessTests : CalculatorsTests
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
        [TestCase(0, Link.None, 0.7925)]
        [TestCase(0, Link.Start, 1.195)]
        [TestCase(0, Link.End, 1.0567)]
        [TestCase(0, Link.Both, 1.2925)]
        [TestCase(0, Link.Cycle, 1.39)]

        [TestCase(1, Link.None, 1.1073)]
        [TestCase(1, Link.Start, 1.3305)]
        [TestCase(1, Link.End, 1.3305)]
        [TestCase(1, Link.Both, 1.4644)]
        [TestCase(1, Link.Cycle, 1.5323)]

        [TestCase(2, Link.None, 0)]
        [TestCase(2, Link.Start, 0)]
        [TestCase(2, Link.End, 0)]
        [TestCase(2, Link.Both, 0)]
        [TestCase(2, Link.Cycle, 0)]

        [TestCase(3, Link.None, 0)]
        [TestCase(3, Link.Start, 3)]
        [TestCase(3, Link.End, 0)]
        [TestCase(3, Link.Both, 1.5)]
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
        [TestCase(0, Link.None, 1.0242)]
        [TestCase(0, Link.Start, 1.1077)]
        [TestCase(0, Link.End, 1.017)]
        [TestCase(0, Link.Both, 1.0828)]
        [TestCase(0, Link.Cycle, 1.234)]
        public void ChainCalculationTest(int index, Link link, double value)
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
        [TestCase(7, Link.None, 0)]
        public void NoIntervalsTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
