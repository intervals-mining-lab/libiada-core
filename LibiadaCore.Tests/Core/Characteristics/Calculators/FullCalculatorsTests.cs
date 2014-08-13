﻿namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The abstract calculator test.
    /// </summary>
    public abstract class FullCalculatorsTests
    {
        /// <summary>
        /// The chains.
        /// </summary>
        protected readonly List<Chain> Chains = ChainsStorage.Chains;

        /// <summary>
        /// Gets or sets the calculator.
        /// </summary>
        protected IFullCalculator Calculator { private get; set; }

        /// <summary>
        /// The chain characteristic test.
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
        protected void ChainCharacteristicTest(int index, Link link, double value)
        {
            Chains[index].FillIntervalManagers();
            Assert.AreEqual(value, Calculator.Calculate(Chains[index], link), 0.0001);
        }
    }
}