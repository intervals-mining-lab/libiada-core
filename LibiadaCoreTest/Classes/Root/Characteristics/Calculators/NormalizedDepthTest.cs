namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    [TestFixture]
    public class NormalizedDepthTest : AbstractCalculatorTest
    {
        public NormalizedDepthTest()
        {
            calc = new NormalizedDepth();
        }

        [Test]
        public void CongenericCalculationTest()
        {
            var depth = new Depth();
            var length = new Length();
            double theory = depth.Calculate(CongenericChains[0], Link.Start) /
                        length.Calculate(CongenericChains[0], Link.Both);

            CongenericChainCharacteristicTest(0, Link.Start, theory);

            theory = depth.Calculate(CongenericChains[0], Link.End) /
                        length.Calculate(CongenericChains[0], Link.Both);

            CongenericChainCharacteristicTest(0, Link.End, theory);

            theory = depth.Calculate(CongenericChains[0], Link.Both) /
                        length.Calculate(CongenericChains[0], Link.Both);

            CongenericChainCharacteristicTest(0, Link.Both, theory);
        }

        [Test]
        public void ChainCalculationTest()
        {
            var depth = new Depth();
            var length = new Length();

            double theory = depth.Calculate(Chains[0], Link.Start) /
                        length.Calculate(Chains[0], Link.Both);
            ChainCharacteristicTest(0, Link.Start, theory);

            theory = depth.Calculate(Chains[0], Link.End) /
                        length.Calculate(Chains[0], Link.Both);
            ChainCharacteristicTest(0, Link.End, theory);

            theory = depth.Calculate(Chains[0], Link.Both) /
                        length.Calculate(Chains[0], Link.Both);

            ChainCharacteristicTest(0, Link.Both, theory);
        }
    }
}