using LibiadaCore.Classes.Root;
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
            AlphabetPower alphabetPower = new AlphabetPower();

            Assert.AreEqual(1, alphabetPower.Calculate(TestUChain, LinkUp.Start));
            Assert.AreEqual(1, alphabetPower.Calculate(TestUChain, LinkUp.End));
            Assert.AreEqual(1, alphabetPower.Calculate(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            AlphabetPower alphabetPower = new AlphabetPower();
            const int power = 3;
            Assert.AreEqual(power, TestChain.Alphabet.Power);
            Assert.AreEqual(power, alphabetPower.Calculate(TestChain, LinkUp.Start));
            Assert.AreEqual(power, alphabetPower.Calculate(TestChain, LinkUp.End));
            Assert.AreEqual(power, alphabetPower.Calculate(TestChain, LinkUp.Both));
        }
    }
}