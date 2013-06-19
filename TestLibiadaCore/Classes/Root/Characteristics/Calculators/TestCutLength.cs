using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCutLength : AbstractCalculatorTest
    {
        [Test]
        public void TestCutLengthChain()
        {
            CutLength cutLength = new CutLength();


            Assert.AreEqual(3, cutLength.Calculate(Chains[0], LinkUp.Both));
            Assert.AreEqual(3, cutLength.Calculate(Chains[0], LinkUp.Start));
            Assert.AreEqual(3, cutLength.Calculate(Chains[0], LinkUp.End));
        }

        [Test]
        public void TestCutLengthUChain()
        {
            CutLength cutLength = new CutLength();

            Assert.AreEqual(4, cutLength.Calculate(uniformChains[0], LinkUp.Both));
            Assert.AreEqual(4, cutLength.Calculate(uniformChains[0], LinkUp.Start));
            Assert.AreEqual(4, cutLength.Calculate(uniformChains[0], LinkUp.End));
        }
    }
}