using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
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
            ObjectMother Mother = new ObjectMother();
            TestUChain = Mother.TestUniformChain();
            TestChain = Mother.TestChain();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculation()
        {
            Characteristic Length = new Characteristic(new Length());

            int LengthUniformChain = 10;
            Assert.AreEqual(8, Length.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(7, Length.Value(TestUChain, LinkUp.End));
            Assert.AreEqual(LengthUniformChain, Length.Value(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic Length = new Characteristic(new Length());

            int LengthChain = 10;
            Assert.AreEqual(LengthChain, Length.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(LengthChain, Length.Value(TestChain, LinkUp.End));
            Assert.AreEqual(LengthChain, Length.Value(TestChain, LinkUp.Both));
        }
    }
}