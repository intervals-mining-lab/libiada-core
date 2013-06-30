using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
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
            Assert.AreEqual(firstValue, calc.Calculate(Chains[index], Elements["a"], Elements["b"], LinkUp.End), 0.0001);
            Assert.AreEqual(secondValue, calc.Calculate(Chains[index], Elements["b"], Elements["a"], LinkUp.End), 0.0001);
        }
    }
}