using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestArithmeticMean
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
            ArithmeticMean arithmeticMean = new ArithmeticMean();
            double n = 10;
            double nj = 3;

            Assert.AreEqual(n / nj, arithmeticMean.Calculate(TestUChain, LinkUp.Start));
            Assert.AreEqual(n / nj, arithmeticMean.Calculate(TestUChain, LinkUp.End));
            Assert.AreEqual(n / nj, arithmeticMean.Calculate(TestUChain, LinkUp.Both));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            ArithmeticMean arithmeticMean = new ArithmeticMean();
            double n = 10;
            double n_A = 3;
            double n_B = 4;
            double n_C = 3;
            double sum_ariphmetical = (n/n_A) + (n/n_B) + (n/n_C);
            int Alphabet_power = 3;
            Assert.AreEqual(Alphabet_power, TestChain.Alphabet.Power);
            Assert.AreEqual(sum_ariphmetical / Alphabet_power, arithmeticMean.Calculate(TestChain, LinkUp.Start));
            Assert.AreEqual(sum_ariphmetical / Alphabet_power, arithmeticMean.Calculate(TestChain, LinkUp.End));
            Assert.AreEqual(sum_ariphmetical / Alphabet_power, arithmeticMean.Calculate(TestChain, LinkUp.Both));
        }
    }
}