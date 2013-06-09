using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestAlphabetPower
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
            Characteristic deltaA = new Characteristic(new AlphabetPower());
   

            Assert.AreEqual(1, deltaA.Value(TestUChain, LinkUp.Start));
            Assert.AreEqual(1, deltaA.Value(TestUChain, LinkUp.End));
            Assert.AreEqual(1, deltaA.Value(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic deltaA = new Characteristic(new AlphabetPower());
            int Alphabet_power = 3;
            Assert.AreEqual(Alphabet_power, TestChain.Alphabet.Power);
            Assert.AreEqual(Alphabet_power, deltaA.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(Alphabet_power, deltaA.Value(TestChain, LinkUp.End));
            Assert.AreEqual(Alphabet_power, deltaA.Value(TestChain, LinkUp.Both));
        }
    }
}