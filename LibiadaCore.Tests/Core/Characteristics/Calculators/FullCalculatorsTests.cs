namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics;
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
        private readonly List<Chain> chains = ChainsStorage.Chains;

        /// <summary>
        /// Gets or sets the calculator.
        /// </summary>
        private IFullCalculator Calculator { get; set; }

        /// <summary>
        /// The initialization.
        /// </summary>
        /// <param name="calculator">
        /// The calculator.
        /// </param>
        protected void Initialization(string calculator)
        {
            Calculator = CalculatorsFactory.CreateFullCalculator(calculator);
        }

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
            chains[index].FillIntervalManagers();
            Assert.AreEqual(value, Calculator.Calculate(chains[index], link), 0.0001);
        }
    }
}
