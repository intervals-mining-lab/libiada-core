using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestProbability : AbstractCalculatorTest
    {
        [TestCase(0, LinkUp.Start, 0.3)]
        [TestCase(0, LinkUp.End, 0.3)]
        [TestCase(0, LinkUp.Both, 0.3)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            Probability calc = new Probability();

            TestUniformChainCharacteristic(index, calc, linkUp, value);
        }

        [TestCase(0, LinkUp.Start, 1)]
        [TestCase(0, LinkUp.End, 1)]
        [TestCase(0, LinkUp.Both, 1)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            Probability calc = new Probability();

            TestChainCharacteristic(index, calc, linkUp, value);
        }
    }
}