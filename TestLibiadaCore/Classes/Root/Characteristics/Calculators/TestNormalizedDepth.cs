using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{

    [TestFixture]
    public class TestNormalizedDepth : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculation()
        {
            NormalizedDepth normalizedDepth = new NormalizedDepth();
            Depth depth = new Depth();
            Length length = new Length();
            double theory = depth.Calculate(uniformChains[0], LinkUp.Start) /
                        length.Calculate(uniformChains[0], LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(uniformChains[0], LinkUp.Start));

            theory = depth.Calculate(uniformChains[0], LinkUp.End) /
                        length.Calculate(uniformChains[0], LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(uniformChains[0], LinkUp.End));

            theory = depth.Calculate(uniformChains[0], LinkUp.Both) /
                        length.Calculate(uniformChains[0], LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(uniformChains[0], LinkUp.Both));
        }

        [Test]
        public void TestCalculationForChain()
        {
            NormalizedDepth normalizedDepth = new NormalizedDepth();
            Depth depth = new Depth();
            Length length = new Length();

            double theory = depth.Calculate(Chains[0], LinkUp.Start) /
                        length.Calculate(Chains[0], LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(Chains[0], LinkUp.Start));

            theory = depth.Calculate(Chains[0], LinkUp.End) /
                        length.Calculate(Chains[0], LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(Chains[0], LinkUp.End));

            theory = depth.Calculate(Chains[0], LinkUp.Both) /
                        length.Calculate(Chains[0], LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(Chains[0], LinkUp.Both));
        }
    }
}