namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The abstract binary calculator test.
    /// </summary>
    public abstract class BinaryCalculatorsTests
    {
        /// <summary>
        /// The chains.
        /// </summary>
        protected readonly List<Chain> Chains = ChainsStorage.BinaryChains;

        /// <summary>
        /// The elements.
        /// </summary>
        private readonly Dictionary<string, IBaseObject> elements = ChainsStorage.Elements;

        /// <summary>
        /// Gets the calculator.
        /// </summary>
        protected IBinaryCalculator Calculator { get; private set; }

        /// <summary>
        /// The initialization.
        /// </summary>
        /// <param name="calculator">
        /// The calculator.
        /// </param>
        protected void Initialization(string calculator)
        {
            Calculator = CalculatorsFactory.CreateBinaryCalculator(calculator);
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
            double result1 = Calculator.Calculate(Chains[index].GetRelationIntervalsManager(elements["a"], elements["b"]), Link.End);
            double result2 = Calculator.Calculate(Chains[index].GetRelationIntervalsManager(elements["b"], elements["a"]), Link.End);
            Assert.AreEqual(firstValue, result1, 0.0001);
            Assert.AreEqual(secondValue, result2, 0.0001);
        }
    }
}