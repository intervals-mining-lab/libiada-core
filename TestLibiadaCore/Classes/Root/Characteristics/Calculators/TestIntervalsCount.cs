using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestIntervalsCount
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
            IntervalsCount intervalsCount = new IntervalsCount();
            int elementCount = 4;
            Assert.AreEqual(elementCount, intervalsCount.Calculate(TestUChain, LinkUp.Both));

            elementCount = 3;
            Assert.AreEqual(elementCount, intervalsCount.Calculate(TestUChain, LinkUp.Start));
            Assert.AreEqual(elementCount, intervalsCount.Calculate(TestUChain, LinkUp.End));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            IntervalsCount intervalsCount = new IntervalsCount();
            int elementCount = 13;
            Assert.AreEqual(elementCount, intervalsCount.Calculate(TestChain, LinkUp.Both));

            elementCount = 10;
            Assert.AreEqual(elementCount, intervalsCount.Calculate(TestChain, LinkUp.Start));
            Assert.AreEqual(elementCount, intervalsCount.Calculate(TestChain, LinkUp.End));
        }
    }
}