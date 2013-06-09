using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
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
        public void init()
        {
            ObjectMother Mother = new ObjectMother();
            TestUChain = Mother.TestUniformChain();
            TestChain = Mother.TestChain();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculation()
        {
            Characteristic N = new Characteristic(new IntervalsCount());
            int ElementCount = 4;
            Assert.AreEqual(ElementCount, N.Value(TestUChain, LinkUp.Both));

            ElementCount = 3;
            Assert.AreEqual(ElementCount, N.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(ElementCount, N.Value(TestUChain, LinkUp.End));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic N = new Characteristic(new IntervalsCount());
            int ElementCount = 13;
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.Both));

            ElementCount = 10;
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(ElementCount, N.Value(TestChain, LinkUp.End));
        }
    }
}