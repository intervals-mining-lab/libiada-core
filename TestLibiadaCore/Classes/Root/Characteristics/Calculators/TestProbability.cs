using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestProbability : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculationForUniformChain()
        {
            Probability probability = new Probability();
            int elementCount = 3;
            double length = 10;
            Assert.AreEqual(elementCount / length, probability.Calculate(uniformChains[0], LinkUp.Both));
            Assert.AreEqual(elementCount / length, probability.Calculate(uniformChains[0], LinkUp.Start));
            Assert.AreEqual(elementCount / length, probability.Calculate(uniformChains[0], LinkUp.End));
        }

        [Test]
        public void TestCalculationForChain()
        {
            Probability probability = new Probability();
            Assert.AreEqual(1, probability.Calculate(Chains[0], LinkUp.Both));
            Assert.AreEqual(1, probability.Calculate(Chains[0], LinkUp.Start));
            Assert.AreEqual(1, probability.Calculate(Chains[0], LinkUp.End));
        }
    }
}