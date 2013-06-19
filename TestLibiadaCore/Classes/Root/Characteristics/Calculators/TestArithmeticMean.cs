using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestArithmeticMean : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            ArithmeticMean calc = new ArithmeticMean();
            double n = 10;
            double nj = 3;

            TestUniformChainCharacteristic(0, calc, LinkUp.Start, n / nj);
            TestUniformChainCharacteristic(0, calc, LinkUp.End, n / nj);
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, n / nj);
        }

        [Test]
        public void TestChainCalculation()
        {
            ArithmeticMean calc = new ArithmeticMean();
            double n = 10;
            double n_A = 3;
            double n_B = 4;
            double n_C = 3;
            double sumAriphmetical = (n/n_A) + (n/n_B) + (n/n_C);
            int alphabetPower = 3;

            TestChainCharacteristic(0, calc, LinkUp.Start, sumAriphmetical / alphabetPower);
            TestChainCharacteristic(0, calc, LinkUp.End, sumAriphmetical / alphabetPower);
            TestChainCharacteristic(0, calc, LinkUp.Both, sumAriphmetical / alphabetPower);
        }
    }
}