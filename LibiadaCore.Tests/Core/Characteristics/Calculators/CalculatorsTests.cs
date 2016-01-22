namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The calculators tests.
    /// </summary>
    public abstract class CalculatorsTests
    {
        /// <summary>
        /// The congeneric chains.
        /// </summary>
        protected readonly List<CongenericChain> CongenericChains = ChainsStorage.CongenericChains;

        /// <summary>
        /// The chains.
        /// </summary>
        protected readonly List<Chain> Chains = ChainsStorage.Chains;

        /// <summary>
        /// Gets or sets the calculator.
        /// </summary>
        private ICalculator Calculator { get; set; }

        /// <summary>
        /// Calculator initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            var testClassName = this.GetType().Name;
            var calculatorName = testClassName.Substring(0, testClassName.Length - 5);
            Calculator = CalculatorsFactory.CreateCalculator(calculatorName);
        }

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
            Assert.AreEqual(value, Calculator.Calculate(CongenericChains[index], link), 0.0001);
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
            Chains[index].FillIntervalManagers();
            Assert.AreEqual(value, Calculator.Calculate(Chains[index], link), 0.0001);
        }
    }
}
