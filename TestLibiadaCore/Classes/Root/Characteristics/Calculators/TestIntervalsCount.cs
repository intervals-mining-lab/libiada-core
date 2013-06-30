using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestIntervalsCount : AbstractCalculatorTest
    {
        public TestIntervalsCount()
        {
            calc = new IntervalsCount();
        }

        [TestCase(0, LinkUp.None, 2)]
        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 4)]
        [TestCase(0, LinkUp.Cycle, 3)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            TestUniformChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 7)]
        [TestCase(0, LinkUp.Start, 10)]
        [TestCase(0, LinkUp.End, 10)]
        [TestCase(0, LinkUp.Both, 13)]
        [TestCase(0, LinkUp.Cycle, 10)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}