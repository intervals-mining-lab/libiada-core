namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The remoteness dispersion tests.
    /// </summary>
    [TestFixture]
    public class RemotenessDispersionTests : FullCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("RemotenessDispersion");
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
        [TestCase(0, Link.None, 0.8114)]
        [TestCase(0, Link.Start, 0.8658)]
        [TestCase(0, Link.End, 0.7681)]
        [TestCase(0, Link.Both, 0.8219)]
        [TestCase(0, Link.Cycle, 1.1161)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        } 
    }
}
