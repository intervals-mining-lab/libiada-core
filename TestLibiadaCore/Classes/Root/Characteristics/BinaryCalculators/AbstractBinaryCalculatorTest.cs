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

        public void CalculationTest(BinaryCharacteristicCalculator calc, int index, string firstElement, string secondElement, double value)
        {
            Assert.AreEqual(value, calc.Calculate(Chains[index], Elements[firstElement], Elements[secondElement], LinkUp.End), 0.0001);
        }
    }
}