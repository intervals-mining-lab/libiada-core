namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The calculators tests.
    /// </summary>
    /// <typeparam name="T">
    /// Characteristic calculator type.
    /// </typeparam>
    public abstract class CongenericCalculatorsTests<T> where T : ICongenericCalculator, new()
    {
        /// <summary>
        /// The congeneric chains.
        /// </summary>
        private readonly List<CongenericChain> congenericChains = ChainsStorage.CongenericChains;

        /// <summary>
        /// Gets or sets the calculator.
        /// </summary>
        private readonly T calculator = new T();

        /// <summary>
        /// The congeneric chain characteristic test.
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
        protected void CongenericChainCharacteristicTest(int index, Link link, double value)
        {
            Assert.AreEqual(value, calculator.Calculate(congenericChains[index], link), 0.0001);
        }
    }
}
