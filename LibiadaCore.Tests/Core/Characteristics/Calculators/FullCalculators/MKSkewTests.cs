﻿namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class MKSkewTests : FullCalculatorsTests<MKSkew>
    {
        /// <summary>
        /// The calculation test.
        /// </summary>
        /// <param name="index">
        /// Full sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(1, 0)]
        public void CalculationTest(int index, double value)
        {
            ChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}
