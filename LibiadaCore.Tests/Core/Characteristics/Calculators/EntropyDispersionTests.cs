namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The average remoteness dispersion test.
    /// </summary>
    [TestFixture]
    public class EntropyDispersionTests : FullCalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("EntropyDispersion");
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
        [TestCase(0, Link.None, 0.0704)]
        [TestCase(0, Link.Start, 0.0168)]
        [TestCase(0, Link.End, 0.0169)]
        [TestCase(0, Link.Both, 0.0514)]
        [TestCase(0, Link.Cycle, 0.0365)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        }
    }
}
