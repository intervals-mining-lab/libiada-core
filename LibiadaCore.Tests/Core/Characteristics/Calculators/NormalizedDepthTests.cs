namespace LibiadaCore.Tests.Core.Characteristics.Calculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The normalized depth test.
    /// </summary>
    [TestFixture]
    public class NormalizedDepthTests : CalculatorsTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            Initialization("NormalizedDepth");
        }

        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
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

        /// <summary>
        /// The chain calculation test.
        /// </summary>
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