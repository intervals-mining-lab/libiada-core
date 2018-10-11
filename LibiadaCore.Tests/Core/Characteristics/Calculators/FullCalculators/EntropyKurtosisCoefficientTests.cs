﻿namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The entropy kurtosis coefficient tests.
    /// </summary>
    [TestFixture]
    public class EntropyKurtosisCoefficientTests : FullCalculatorsTests<EntropyKurtosisCoefficient>
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
        [TestCase(0, Link.Cycle, 1.00005)]
        [TestCase(1, Link.Cycle, 1.00144)]
        [TestCase(2, Link.Cycle, 1.00609)]
        [TestCase(3, Link.Cycle, 1)]
        [TestCase(4, Link.Cycle, 0)]
        [TestCase(5, Link.Cycle, 1)]
        [TestCase(6, Link.Cycle, 1.00236)]
        [TestCase(7, Link.Cycle, 1)]
        [TestCase(8, Link.Cycle, 0)]
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
