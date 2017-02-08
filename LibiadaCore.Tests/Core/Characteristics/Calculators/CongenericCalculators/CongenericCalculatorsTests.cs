namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The calculators tests.
    /// </summary>
    public abstract class CongenericCalculatorsTests
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
        private ICongenericCalculator Calculator { get; set; }

        /// <summary>
        /// Calculator initialization method.
        /// </summary>
        [OneTimeSetUp]
        public void Initialization()
        {
            var testClassName = this.GetType().Name;
            var calculatorName = testClassName.Substring(0, testClassName.Length - 5);
            Calculator = CongenericCalculatorsFactory.CreateCongenericCalculator(calculatorName);
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
    }
}
