using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCount : AbstractCalculatorTest
    {
        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 3)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            Count calc = new Count();

            TestUniformChainCharacteristic(0, calc, LinkUp.Start, 3);
            TestUniformChainCharacteristic(0, calc, LinkUp.End, 3);
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, 3);
        }

        [TestCase(0, LinkUp.Start, 10)]
        [TestCase(0, LinkUp.End, 10)]
        [TestCase(0, LinkUp.Both, 10)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            Count calc = new Count();

            TestChainCharacteristic(index, calc, linkUp, value);
        }
    }
}