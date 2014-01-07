using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.BinaryCalculators
{
    public abstract class AbstractBinaryCalculatorTest
    {
        protected List<Chain> Chains;
        protected Dictionary<String, IBaseObject> Elements = BinaryCalculationHelper.Elements;

        [SetUp]
        public void Init()
        {
            Chains = BinaryCalculationHelper.Chains;
        }

        public void CalculationTest(BinaryCalculator calc, int index, double firstValue, double secondValue)
        {
            double result1 = calc.Calculate(Chains[index], Elements["a"], Elements["b"], Link.End);
            double result2 = calc.Calculate(Chains[index], Elements["b"], Elements["a"], Link.End);
            Assert.AreEqual(firstValue, result1, 0.0001);
            Assert.AreEqual(secondValue, result2, 0.0001);
        }
    }
}