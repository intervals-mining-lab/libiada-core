namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The abstract calculator test.
    /// </summary>
    public abstract class FullCalculatorsTests<T> where T : IFullCalculator, new ()
    {
        /// <summary>
        /// The chains.
        /// </summary>
        private readonly List<Chain> chains = ChainsStorage.Chains;

        /// <summary>
        /// Gets or sets the calculator.
        /// </summary>
        private T calculator = new T();

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
            Assert.AreEqual(value, calculator.Calculate(chains[index], link), 0.0001);
        }
    }
}
