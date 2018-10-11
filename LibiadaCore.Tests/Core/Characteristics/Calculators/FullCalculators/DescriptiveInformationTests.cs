namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The descriptive information test.
    /// </summary>
    [TestFixture]
    public class DescriptiveInformationTests : FullCalculatorsTests<DescriptiveInformation>
    {
        /// <summary>
        /// The chain calculation test.
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
        [TestCase(0, Link.None, 2.8845)]
        [TestCase(0, Link.Start, 2.9917)]
        [TestCase(0, Link.End, 2.9473)]
        [TestCase(0, Link.Both, 2.9865)]
        [TestCase(0, Link.Cycle, 2.971)]
        public void ChainCalculationTest(int index, Link link, double value)
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
        [TestCase(3, Link.None, 1)]
        [TestCase(5, Link.None, 1)]
        [TestCase(7, Link.None, 1)]
        public void NoIntervalsTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
