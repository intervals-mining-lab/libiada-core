namespace LibiadaCore.Tests.Core.Characteristics.Calculators.AccordanceCalculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.AccordanceCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The accordance calculators tests.
    /// </summary>
    public abstract class AccordanceCalculatorsTests
    {
        /// <summary>
        /// The binary chains.
        /// </summary>
        private readonly List<Chain> chains = ChainsStorage.BinaryChains;

        /// <summary>
        /// The congeneric chains.
        /// </summary>
        private readonly List<CongenericChain> congenericChains = ChainsStorage.CongenericChains;

        /// <summary>
        /// The elements.
        /// </summary>
        private readonly Dictionary<string, IBaseObject> elements = ChainsStorage.Elements;

        /// <summary>
        /// Gets or sets the calculator.
        /// </summary>
        private IAccordanceCalculator Calculator { get; set; }

        /// <summary>
        /// Calculator initialization method.
        /// </summary>
        [OneTimeSetUp]
        public void Initialization()
        {
            var testClassName = this.GetType().Name;
            var calculatorName = testClassName.Substring(0, testClassName.Length - 5);
            this.Calculator = AccordanceCalculatorsFactory.CreateAccordanceCalculator(calculatorName);
        }

        /// <summary>
        /// The calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="firstValue">
        /// The first value.
        /// </param>
        /// <param name="secondValue">
        /// The second value.
        /// </param>
        protected void CalculationTest(int index, double firstValue, double secondValue)
        {
            var firstChain = this.chains[index].CongenericChain(this.elements["A"]);
            var secondChain = this.chains[index].CongenericChain(this.elements["B"]);
            double result1 = this.Calculator.Calculate(firstChain, secondChain, Link.End);
            double result2 = this.Calculator.Calculate(secondChain, firstChain, Link.End);
            Assert.AreEqual(firstValue, result1, 0.0001);
            Assert.AreEqual(secondValue, result2, 0.0001);
        }

        /// <summary>
        /// The calculation test.
        /// </summary>
        /// <param name="firstIndex">
        /// The first index.
        /// </param>
        /// <param name="secondIndex">
        /// The second index.
        /// </param>
        /// <param name="firstValue">
        /// The first value.
        /// </param>
        protected void CalculationTest(int firstIndex, int secondIndex, double firstValue)
        {
            double result = this.Calculator.Calculate(this.congenericChains[firstIndex], this.congenericChains[secondIndex], Link.End);
            Assert.AreEqual(firstValue, result, 0.0001);
        }
    }
}
