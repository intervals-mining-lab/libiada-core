namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The average remoteness kurtosis tests.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessKurtosisTests : FullCalculatorsTests
    {
        /// <summary>
        /// The average remoteness dispersion test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, Link.None, 0.0056)]
        [TestCase(0, Link.Start, 0.0004)]
        [TestCase(0, Link.End, 0.0005)]
        [TestCase(0, Link.Both, 0.0032)]
        [TestCase(0, Link.Cycle, 0.0016)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        }
    }
}
