using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCount : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculation()
        {
            Count count = new Count();
            int elementCount = 3;
            Assert.AreEqual(elementCount, count.Calculate(uniformChains[0], LinkUp.Both));
            Assert.AreEqual(elementCount, count.Calculate(uniformChains[0], LinkUp.Start));
            Assert.AreEqual(elementCount, count.Calculate(uniformChains[0], LinkUp.End));
        }

        [Test]
        public void TestCalculatorForChain()
        {
            Count count = new Count();
            int elementCount = 10;
            Assert.AreEqual(elementCount, count.Calculate(Chains[0], LinkUp.Start));
            Assert.AreEqual(elementCount, count.Calculate(Chains[0], LinkUp.Both));
            Assert.AreEqual(elementCount, count.Calculate(Chains[0], LinkUp.End));
        }
    }
}