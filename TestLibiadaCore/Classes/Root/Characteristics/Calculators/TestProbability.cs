using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestProbability : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            Probability calc = new Probability();

            TestUniformChainCharacteristic(0, calc, LinkUp.Start, 0.3);
            TestUniformChainCharacteristic(0, calc, LinkUp.End, 0.3);
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, 0.3);
        }

        [Test]
        public void TestChainCalculation()
        {
            Probability calc = new Probability();

            TestChainCharacteristic(0, calc, LinkUp.Start, 1);
            TestChainCharacteristic(0, calc, LinkUp.End, 1);
            TestChainCharacteristic(0, calc, LinkUp.Both, 1);
        }
    }
}