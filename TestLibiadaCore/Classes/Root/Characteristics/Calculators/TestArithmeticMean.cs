using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestArithmeticMean : AbstractCalculatorTest
    {
        [Test]
        public void TestCalculation()
        {
            ArithmeticMean arithmeticMean = new ArithmeticMean();
            double n = 10;
            double nj = 3;

            Assert.AreEqual(n / nj, arithmeticMean.Calculate(uniformChains[0], LinkUp.Start));
            Assert.AreEqual(n / nj, arithmeticMean.Calculate(uniformChains[0], LinkUp.End));
            Assert.AreEqual(n / nj, arithmeticMean.Calculate(uniformChains[0], LinkUp.Both));
        }

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
            Assert.AreEqual(Alphabet_power, Chains[0].Alphabet.Power);
            Assert.AreEqual(sum_ariphmetical / Alphabet_power, arithmeticMean.Calculate(Chains[0], LinkUp.Start));
            Assert.AreEqual(sum_ariphmetical / Alphabet_power, arithmeticMean.Calculate(Chains[0], LinkUp.End));
            Assert.AreEqual(sum_ariphmetical / Alphabet_power, arithmeticMean.Calculate(Chains[0], LinkUp.Both));
        }
    }
}