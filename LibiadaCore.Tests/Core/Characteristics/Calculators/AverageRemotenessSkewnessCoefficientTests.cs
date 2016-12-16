namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The average remoteness asymmetry test.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessSkewnessCoefficientTests : FullCalculatorsTests
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
        [TestCase(0, Link.None, 0.2887)]
        [TestCase(0, Link.Start, 0.7691)]
        [TestCase(0, Link.End, 0.2583)]
        [TestCase(0, Link.Both, -0.4341)]
        [TestCase(0, Link.Cycle, -0.4082)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
