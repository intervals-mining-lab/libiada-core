using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{

    [TestFixture]
    public class TestNormalizedDepth : AbstractCalculatorTest
    {
        public TestNormalizedDepth()
        {
            calc = new NormalizedDepth();
        }

        [Test]
        public void TestCongenericCalculation()
        {
            Depth depth = new Depth();
            Length length = new Length();
            double theory = depth.Calculate(CongenericChains[0], LinkUp.Start) /
                        length.Calculate(CongenericChains[0], LinkUp.Both);

            TestCongenericChainCharacteristic(0, LinkUp.Start, theory);

            theory = depth.Calculate(CongenericChains[0], LinkUp.End) /
                        length.Calculate(CongenericChains[0], LinkUp.Both);

            TestCongenericChainCharacteristic(0, LinkUp.End, theory);

            theory = depth.Calculate(CongenericChains[0], LinkUp.Both) /
                        length.Calculate(CongenericChains[0], LinkUp.Both);

            TestCongenericChainCharacteristic(0, LinkUp.Both, theory);
        }

        [Test]
        public void TestChainCalculation()
        {
            Depth depth = new Depth();
            Length length = new Length();

            double theory = depth.Calculate(Chains[0], LinkUp.Start) /
                        length.Calculate(Chains[0], LinkUp.Both);
            TestChainCharacteristic(0, LinkUp.Start, theory);

            theory = depth.Calculate(Chains[0], LinkUp.End) /
                        length.Calculate(Chains[0], LinkUp.Both);
            TestChainCharacteristic(0, LinkUp.End, theory);

            theory = depth.Calculate(Chains[0], LinkUp.Both) /
                        length.Calculate(Chains[0], LinkUp.Both);

            TestChainCharacteristic(0, LinkUp.Both, theory);
        }
    }
}