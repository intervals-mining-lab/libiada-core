namespace LibiadaCore.Tests.Core.Characteristics.BinaryCalculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.BinaryCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The abstract binary calculator test.
    /// </summary>
    public abstract class AbstractBinaryCalculatorTests
    {
        /// <summary>
        /// The chains.
        /// </summary>
        protected readonly List<Chain> Chains = BinaryCalculationHelper.Chains;

        /// <summary>
        /// The elements.
        /// </summary>
        private readonly Dictionary<string, IBaseObject> elements = BinaryCalculationHelper.Elements;

        /// <summary>
        /// Gets or sets the calculator.
        /// </summary>
        protected IBinaryCalculator Calculator { get; set; }

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
            double result1 = Calculator.Calculate(Chains[index], elements["a"], elements["b"], Link.End);
            double result2 = Calculator.Calculate(Chains[index], elements["b"], elements["a"], Link.End);
            Assert.AreEqual(firstValue, result1, 0.0001);
            Assert.AreEqual(secondValue, result2, 0.0001);
        }
    }
}