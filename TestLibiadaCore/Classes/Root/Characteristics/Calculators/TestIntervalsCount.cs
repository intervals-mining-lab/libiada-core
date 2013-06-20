using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestIntervalsCount : AbstractCalculatorTest
    {
        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 4)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            IntervalsCount calc = new IntervalsCount();

            TestUniformChainCharacteristic(index, calc, linkUp, value);
        }

        [TestCase(0, LinkUp.Start, 10)]
        [TestCase(0, LinkUp.End, 10)]
        [TestCase(0, LinkUp.Both, 13)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            IntervalsCount calc = new IntervalsCount();

            TestChainCharacteristic(index, calc, linkUp, value);
        }
    }
}