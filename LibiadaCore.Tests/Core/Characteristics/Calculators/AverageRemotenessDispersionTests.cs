﻿using System;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The average remoteness dispersion test.
    /// </summary>
    [TestFixture]
    public class AverageRemotenessDispersionTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Calculator = new AverageRemotenessDispersion();
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

        [ExpectedException(typeof(InvalidOperationException))]
        [TestCase(0, Link.Both, 0)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 0.0704)]
        [TestCase(0, Link.Start, 0.1168)]
        [TestCase(0, Link.End, 0.0169)]
        [TestCase(0, Link.Both, 0.0515)]
        [TestCase(0, Link.Cycle, 0.1872)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        }
    }
}