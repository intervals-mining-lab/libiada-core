﻿using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    public abstract class AbstractCalculatorTest
    {
        protected List<UniformChain> UniformChains;
        protected List<Chain> Chains;

        [SetUp]
        public void Init()
        {
            UniformChains = CalculationHelper.UniformChains;
            Chains = CalculationHelper.Chains;
        }

        public void TestChainCharacteristic(int index, ICharacteristicCalculator calc, LinkUp linkUp, double value)
        {
            Assert.AreEqual(value, calc.Calculate(Chains[index], linkUp), 0.0001);
        }

        public void TestUniformChainCharacteristic(int index, ICharacteristicCalculator calc, LinkUp linkUp, double value)
        {
            Assert.AreEqual(value, calc.Calculate(UniformChains[index], linkUp), 0.0001);
        }
    }
}