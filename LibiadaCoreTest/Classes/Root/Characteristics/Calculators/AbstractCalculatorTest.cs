namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    public abstract class AbstractCalculatorTest
    {
        protected List<CongenericChain> CongenericChains = ChainsStorage.CongenericChains;
        protected List<Chain> Chains = ChainsStorage.Chains;
        protected ICalculator calc;

        public void ChainCharacteristicTest(int index, Link link, double value)
        {
            Assert.AreEqual(value, calc.Calculate(Chains[index], link), 0.0001);
        }

        public void CongenericChainCharacteristicTest(int index, Link link, double value)
        {
            Assert.AreEqual(value, calc.Calculate(CongenericChains[index], link), 0.0001);
        }
    }
}