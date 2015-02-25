namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// Standard Deviation test.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessStandardDeviationTests : FullCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("AverageRemotenessStandardDeviation");
        }

        /// <summary>
        /// Standard Deviation test.
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
        [TestCase(0, Link.None, 0.2677)]
        [TestCase(0, Link.Start, 0.1296)]
        [TestCase(0, Link.End, 0.1298)]
        [TestCase(0, Link.Both, 0.225)]
        [TestCase(0, Link.Cycle, 0.191)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        }
    }
}
