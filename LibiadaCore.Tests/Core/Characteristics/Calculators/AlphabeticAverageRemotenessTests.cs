﻿namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The alphabetic average remoteness test.
    /// </summary>
    [TestFixture]
    public class AlphabeticAverageRemotenessTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new AlphabeticAverageRemoteness();
        }

        /// <summary>
        /// The alphabetic average remoteness test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        

        public void CongenericCalculationTest(int index, Link link, double value)
        {
            this.CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 0.6462)]
        [TestCase(0, Link.Start, 0.6989)]
        [TestCase(0, Link.End, 0.6417)]
        [TestCase(0, Link.Both, 0.6832)]
        [TestCase(0, Link.Cycle, 0.7786)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            this.ChainCharacteristicTest(0, link, value);
        }
    }
}