using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestLength : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculation()
        {
            Length length = new Length();

            Assert.AreEqual(10, length.Calculate(uniformChains[0], LinkUp.Start));
            Assert.AreEqual(10, length.Calculate(uniformChains[0], LinkUp.End));
            Assert.AreEqual(10, length.Calculate(uniformChains[0], LinkUp.Both));
        }

        [Test]
        public void TestCalculationForChain()
        {
            Length length = new Length();

            const int chainLength = 10;
            Assert.AreEqual(chainLength, length.Calculate(Chains[0], LinkUp.Start));
            Assert.AreEqual(chainLength, length.Calculate(Chains[0], LinkUp.End));
            Assert.AreEqual(chainLength, length.Calculate(Chains[0], LinkUp.Both));
        }
    }
}