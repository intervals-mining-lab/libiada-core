namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics;
    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.IntervalsManagers;

    using NUnit.Framework;

    /// <summary>
    /// The accordance calculators tests.
    /// </summary>
    public abstract class AccordanceCalculatorsTests
    {
        /// <summary>
        /// The binary chains.
        /// </summary>
        protected readonly List<Chain> Chains = ChainsStorage.BinaryChains;

        /// <summary>
        /// The congeneric chains.
        /// </summary>
        protected readonly List<CongenericChain> CongenericChains = ChainsStorage.CongenericChains;

        /// <summary>
        /// The elements.
        /// </summary>
        private readonly Dictionary<string, IBaseObject> elements = ChainsStorage.Elements;

        /// <summary>
        /// Gets the calculator.
        /// </summary>
        protected IAccordanceCalculator Calculator { get; private set; }

        /// <summary>
        /// The initialization.
        /// </summary>
        /// <param name="calculator">
        /// The calculator.
        /// </param>
        protected void Initialization(string calculator)
        {
            Calculator = CalculatorsFactory.CreateAccordanceCalculator(calculator);
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
            var firstChain = Chains[index].CongenericChain(elements["A"]);
            var secondChain = Chains[index].CongenericChain(elements["B"]);
            double result1 = Calculator.Calculate(firstChain, secondChain, Link.End);
            double result2 = Calculator.Calculate(secondChain, firstChain, Link.End);
            Assert.AreEqual(firstValue, result1, 0.0001);
            Assert.AreEqual(secondValue, result2, 0.0001);
        }

        protected void CalculationTest(int firstIndex, int secondIndex, double firstValue)
        {
            double result = Calculator.Calculate(CongenericChains[firstIndex], CongenericChains[secondIndex], Link.End);
            Assert.AreEqual(firstValue, result, 0.0001);
        }

    }
}
