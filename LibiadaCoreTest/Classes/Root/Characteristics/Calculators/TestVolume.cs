using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;
using LibiadaCore.Classes.Root;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestVolume : AbstractCalculatorTest
    {
        public TestVolume()
        {
            calc = new Volume();
        }

        [TestCase(0, LinkUp.None, 3)]
        [TestCase(0, LinkUp.Start, 12)]
        [TestCase(0, LinkUp.End, 9)]
        [TestCase(0, LinkUp.Both, 36)]
        [TestCase(0, LinkUp.Cycle, 18)]
        public void TestCongenericCalculation(int index, LinkUp linkUp, double value)
        {
            TestCongenericChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 144)]
        [TestCase(0, LinkUp.Start, 2160)]
        [TestCase(0, LinkUp.End, 1152)]
        [TestCase(0, LinkUp.Both, 17280)]
        [TestCase(0, LinkUp.Cycle, 5184)]
        public void TestCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}