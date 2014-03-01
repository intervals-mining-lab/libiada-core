namespace LibiadaCore.Tests.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The normalized depth test.
    /// </summary>
    [TestFixture]
    public class NormalizedDepthTests : AbstractCalculatorTests
    {
        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialization()
        {
            this.Calculator = new NormalizedDepth();
        }

        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
        [Test]
        public void CongenericCalculationTest()
        {
            var depth = new Depth();
            var length = new Length();
            double theory = depth.Calculate(this.CongenericChains[0], Link.Start) /
                        length.Calculate(this.CongenericChains[0], Link.Both);

            this.CongenericChainCharacteristicTest(0, Link.Start, theory);

            theory = depth.Calculate(this.CongenericChains[0], Link.End) /
                        length.Calculate(this.CongenericChains[0], Link.Both);

            this.CongenericChainCharacteristicTest(0, Link.End, theory);

            theory = depth.Calculate(this.CongenericChains[0], Link.Both) /
                        length.Calculate(this.CongenericChains[0], Link.Both);

            this.CongenericChainCharacteristicTest(0, Link.Both, theory);
        }

        /// <summary>
        /// The chain calculation test.
        /// </summary>
        [Test]
        public void ChainCalculationTest()
        {
            var depth = new Depth();
            var length = new Length();

            double theory = depth.Calculate(this.Chains[0], Link.Start) /
                        length.Calculate(this.Chains[0], Link.Both);
            this.ChainCharacteristicTest(0, Link.Start, theory);

            theory = depth.Calculate(this.Chains[0], Link.End) /
                        length.Calculate(this.Chains[0], Link.Both);
            this.ChainCharacteristicTest(0, Link.End, theory);

            theory = depth.Calculate(this.Chains[0], Link.Both) /
                        length.Calculate(this.Chains[0], Link.Both);

            this.ChainCharacteristicTest(0, Link.Both, theory);
        }
    }
}