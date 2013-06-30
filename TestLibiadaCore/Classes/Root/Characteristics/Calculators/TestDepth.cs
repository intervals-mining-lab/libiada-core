using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestDepth : AbstractCalculatorTest
    {
        public TestDepth()
        {
            calc = new Depth();
        }

        [TestCase(0, LinkUp.None, 1.585)]
        [TestCase(0, LinkUp.Start, 3.585)]
        [TestCase(0, LinkUp.End, 3.1699)]
        [TestCase(0, LinkUp.Both, 5.1699)]
        [TestCase(0, LinkUp.Cycle, 4.1699)]
        public void TestCongenericCalculation(int index, LinkUp linkUp, double value)
        {
            TestCongenericChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 7.1699)]
        [TestCase(0, LinkUp.Start, 11.0768)]
        [TestCase(0, LinkUp.End, 10.1699)]
        [TestCase(0, LinkUp.Both, 14.0768)]
        [TestCase(0, LinkUp.Cycle, 12.3399)]
        public void TestCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}