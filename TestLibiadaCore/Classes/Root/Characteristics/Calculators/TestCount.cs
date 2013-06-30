using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCount : AbstractCalculatorTest
    {
        public TestCount()
        {
            calc = new Count();
        }

        [TestCase(0, LinkUp.None, 3)]
        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 3)]
        [TestCase(0, LinkUp.Cycle, 3)]
        public void TestCongenericCalculation(int index, LinkUp linkUp, double value)
        {
            TestCongenericChainCharacteristic(0, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 10)]
        [TestCase(0, LinkUp.Start, 10)]
        [TestCase(0, LinkUp.End, 10)]
        [TestCase(0, LinkUp.Both, 10)]
        [TestCase(0, LinkUp.Cycle, 10)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}