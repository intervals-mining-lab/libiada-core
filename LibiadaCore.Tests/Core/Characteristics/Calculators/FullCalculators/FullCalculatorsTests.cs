namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

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
        /// Calculator initialization method.
        /// </summary>
        [OneTimeSetUp]
        public void Initialization()
        {
            var testClassName = GetType().Name;
            var calculatorName = testClassName.Substring(0, testClassName.Length - 5);
            Calculator = FullCalculatorsFactory.CreateFullCalculator(calculatorName);
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
