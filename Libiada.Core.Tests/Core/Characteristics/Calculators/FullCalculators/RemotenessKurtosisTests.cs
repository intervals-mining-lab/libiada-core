namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The remoteness kurtosis tests.
    /// </summary>
    [TestFixture]
    public class RemotenessKurtosisTests : FullCalculatorsTests<RemotenessKurtosis>
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
        [TestCase(0, Link.None, 0.7589278)]
        [TestCase(0, Link.Start, 0.9619193)]
        [TestCase(0, Link.End, 0.7288246)]
        [TestCase(0, Link.Both, 0.888077)]
        [TestCase(0, Link.Cycle, 1.6655934)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
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
