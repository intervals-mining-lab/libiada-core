using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestProbability
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
        public void TestCalculationForUniformChain()
        {
            Probability probability = new Probability();
            int elementCount = 3;
            double length = 10;
            Assert.AreEqual(elementCount / length, probability.Calculate(TestUChain, LinkUp.Both));
            Assert.AreEqual(elementCount / length, probability.Calculate(TestUChain, LinkUp.Start));
            Assert.AreEqual(elementCount / length, probability.Calculate(TestUChain, LinkUp.End));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Probability probability = new Probability();
            Assert.AreEqual(1, probability.Calculate(TestChain, LinkUp.Both));
            Assert.AreEqual(1, probability.Calculate(TestChain, LinkUp.Start));
            Assert.AreEqual(1, probability.Calculate(TestChain, LinkUp.End));
        }
    }
}