using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestIntervalsCount : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculation()
        {
            IntervalsCount intervalsCount = new IntervalsCount();
            int elementCount = 4;
            Assert.AreEqual(elementCount, intervalsCount.Calculate(uniformChains[0], LinkUp.Both));

            elementCount = 3;
            Assert.AreEqual(elementCount, intervalsCount.Calculate(uniformChains[0], LinkUp.Start));
            Assert.AreEqual(elementCount, intervalsCount.Calculate(uniformChains[0], LinkUp.End));
        }

        [Test]
        public void TestCalculationForChain()
        {
            IntervalsCount intervalsCount = new IntervalsCount();
            int elementCount = 13;
            Assert.AreEqual(elementCount, intervalsCount.Calculate(Chains[0], LinkUp.Both));

            elementCount = 10;
            Assert.AreEqual(elementCount, intervalsCount.Calculate(Chains[0], LinkUp.Start));
            Assert.AreEqual(elementCount, intervalsCount.Calculate(Chains[0], LinkUp.End));
        }
    }
}