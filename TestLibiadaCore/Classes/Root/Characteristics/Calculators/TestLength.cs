using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestLength
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            ChainsForTests Mother = new ChainsForTests();
            TestUChain = Mother.TestUniformChain();
            TestChain = Mother.TestChain();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculation()
        {
            Length length = new Length();

            Assert.AreEqual(10, length.Calculate(TestUChain, LinkUp.Start));
            Assert.AreEqual(10, length.Calculate(TestUChain, LinkUp.End));
            Assert.AreEqual(10, length.Calculate(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Length length = new Length();

            const int chainLength = 10;
            Assert.AreEqual(chainLength, length.Calculate(TestChain, LinkUp.Start));
            Assert.AreEqual(chainLength, length.Calculate(TestChain, LinkUp.End));
            Assert.AreEqual(chainLength, length.Calculate(TestChain, LinkUp.Both));
        }
    }
}