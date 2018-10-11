namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The average remoteness kurtosis coefficient tests.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessKurtosisCoefficientTests : FullCalculatorsTests<AverageRemotenessKurtosisCoefficient>
    {
        /// <summary>
        /// The average remoteness dispersion test.
        /// </summary>
        /// <param name="index">
        /// Full sequence index in <see cref="ChainsStorage"/>.
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
        [TestCase(3, Link.None, 0)]
        [TestCase(5, Link.None, 0)]
        [TestCase(7, Link.None, 0)]
        public void NoIntervalsTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
