using System.Runtime.InteropServices.ComTypes;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.BinaryCalculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The abstract binary calculator test.
    /// </summary>
    public abstract class BinaryCalculatorsTests<T> where T : IBinaryCalculator, new()
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
        /// Gets or sets the calculator.
        /// </summary>
        protected T calculator = new T();

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
            double result1 = calculator.Calculate(Chains[index].GetRelationIntervalsManager(elements["A"], elements["B"]), Link.End);
            double result2 = calculator.Calculate(Chains[index].GetRelationIntervalsManager(elements["B"], elements["A"]), Link.End);
            Assert.AreEqual(firstValue, result1, 0.0001);
            Assert.AreEqual(secondValue, result2, 0.0001);
        }
    }
}
