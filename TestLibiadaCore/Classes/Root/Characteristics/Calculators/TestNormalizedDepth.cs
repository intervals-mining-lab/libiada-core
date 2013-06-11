using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestNormalizedDepth
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            ChainsForTests mother = new ChainsForTests();
            TestUChain = mother.TestUniformChain();
            TestChain = mother.TestChain();
        }


        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculation()
        {
            NormalizedDepth normalizedDepth = new NormalizedDepth();
            Depth depth = new Depth();
            Length length = new Length();
            double theory = depth.Calculate(TestUChain, LinkUp.Start)/
                        length.Calculate(TestUChain, LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(TestUChain, LinkUp.Start));

            theory = depth.Calculate(TestUChain, LinkUp.End) /
                        length.Calculate(TestUChain, LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(TestUChain, LinkUp.End));

            theory = depth.Calculate(TestUChain, LinkUp.Both) /
                        length.Calculate(TestUChain, LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            NormalizedDepth normalizedDepth = new NormalizedDepth();
            Depth depth = new Depth();
            Length length = new Length();

            double theory = depth.Calculate(TestChain, LinkUp.Start) /
                        length.Calculate(TestChain, LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(TestChain, LinkUp.Start));

            theory = depth.Calculate(TestChain, LinkUp.End) /
                        length.Calculate(TestChain, LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(TestChain, LinkUp.End));

            theory = depth.Calculate(TestChain, LinkUp.Both) /
                        length.Calculate(TestChain, LinkUp.Both);

            Assert.AreEqual(theory, normalizedDepth.Calculate(TestChain, LinkUp.Both));
        }
    }
}