using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    public abstract class AbstractCalculatorTest
    {
        protected List<CongenericChain> CongenericChains = CalculationHelper.CongenericChains;
        protected List<Chain> Chains = CalculationHelper.Chains;
        protected ICalculator calc;

        public void TestChainCharacteristic(int index, LinkUp linkUp, double value)
        {
            Assert.AreEqual(value, calc.Calculate(Chains[index], linkUp), 0.0001);
        }

        public void TestCongenericChainCharacteristic(int index, LinkUp linkUp, double value)
        {
            Assert.AreEqual(value, calc.Calculate(CongenericChains[index], linkUp), 0.0001);
        }
    }
}