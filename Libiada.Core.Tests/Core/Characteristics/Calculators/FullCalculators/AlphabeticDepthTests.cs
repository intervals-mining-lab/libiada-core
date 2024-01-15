namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The alphabetic depth test.
    /// </summary>
    [TestFixture]
    public class AlphabeticDepthTests : FullCalculatorsTests<AlphabeticDepth>
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
        [TestCase(0, Link.None, 4.5237)]
        [TestCase(0, Link.Start, 6.9887)]
        [TestCase(0, Link.End, 6.4165)]
        [TestCase(0, Link.Both, 8.8815)]
        [TestCase(0, Link.Cycle, 7.7856)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
