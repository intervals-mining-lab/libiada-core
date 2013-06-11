using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestCount
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
            Count count = new Count();
            int elementCount = 3;
            Assert.AreEqual(elementCount, count.Calculate(TestUChain, LinkUp.Both));
            Assert.AreEqual(elementCount, count.Calculate(TestUChain, LinkUp.Start));
            Assert.AreEqual(elementCount, count.Calculate(TestUChain, LinkUp.End));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculatorForChain()
        {
            Count count = new Count();
            int elementCount = 10;
            Assert.AreEqual(elementCount, count.Calculate(TestChain, LinkUp.Start));
            Assert.AreEqual(elementCount, count.Calculate(TestChain, LinkUp.Both));
            Assert.AreEqual(elementCount, count.Calculate(TestChain, LinkUp.End));
        }
    }
}