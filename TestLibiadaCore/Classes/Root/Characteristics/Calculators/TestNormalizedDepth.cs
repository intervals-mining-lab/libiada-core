using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{

    [TestFixture]
    public class TestNormalizedDepth : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            NormalizedDepth calc = new NormalizedDepth();
            Depth depth = new Depth();
            Length length = new Length();
            double theory = depth.Calculate(uniformChains[0], LinkUp.Start) /
                        length.Calculate(uniformChains[0], LinkUp.Both);

            TestUniformChainCharacteristic(0, calc, LinkUp.Start, theory);

            theory = depth.Calculate(uniformChains[0], LinkUp.End) /
                        length.Calculate(uniformChains[0], LinkUp.Both);

            TestUniformChainCharacteristic(0, calc, LinkUp.End, theory);

            theory = depth.Calculate(uniformChains[0], LinkUp.Both) /
                        length.Calculate(uniformChains[0], LinkUp.Both);

            TestUniformChainCharacteristic(0, calc, LinkUp.Both, theory);
        }

        [Test]
        public void TestChainCalculation()
        {
            NormalizedDepth calc = new NormalizedDepth();
            Depth depth = new Depth();
            Length length = new Length();

            double theory = depth.Calculate(Chains[0], LinkUp.Start) /
                        length.Calculate(Chains[0], LinkUp.Both);
            TestChainCharacteristic(0, calc, LinkUp.Start, theory);

            theory = depth.Calculate(Chains[0], LinkUp.End) /
                        length.Calculate(Chains[0], LinkUp.Both);
            TestChainCharacteristic(0, calc, LinkUp.End, theory);

            theory = depth.Calculate(Chains[0], LinkUp.Both) /
                        length.Calculate(Chains[0], LinkUp.Both);

            TestChainCharacteristic(0, calc, LinkUp.Both, theory);
        }
    }
}