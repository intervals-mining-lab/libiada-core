namespace LibiadaCore.Tests.Classes.Root.Characteristics.BinaryCalculators
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;

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
            double result1 = this.Calculator.Calculate(this.Chains[index], this.elements["a"], this.elements["b"], Link.End);
            double result2 = this.Calculator.Calculate(this.Chains[index], this.elements["b"], this.elements["a"], Link.End);
            Assert.AreEqual(firstValue, result1, 0.0001);
            Assert.AreEqual(secondValue, result2, 0.0001);
        }
    }
}