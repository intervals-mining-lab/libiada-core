namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The alphabetic average remoteness test.
    /// </summary>
    [TestFixture]
    public class AlphabeticAverageRemotenessTests : FullCalculatorsTests<AlphabeticAverageRemoteness>
    {
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
        [TestCase(0, Link.None, 0.6462)]
        [TestCase(0, Link.Start, 0.6989)]
        [TestCase(0, Link.End, 0.6417)]
        [TestCase(0, Link.Both, 0.6832)]
        [TestCase(0, Link.Cycle, 0.7786)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
