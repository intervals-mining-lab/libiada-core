namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The average remoteness kurtosis coefficient tests.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessKurtosisCoefficientTests : FullCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("AverageRemotenessKurtosisCoefficient");
        }

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
        [TestCase(0, Link.None, 1.0833)]
        [TestCase(0, Link.Start, 1.7262)]
        [TestCase(0, Link.End, 1.6741)]
        [TestCase(0, Link.Both, 1.2419)]
        [TestCase(0, Link.Cycle, 1.1666)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        }
    }
}
