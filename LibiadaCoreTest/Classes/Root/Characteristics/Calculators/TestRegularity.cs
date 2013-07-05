using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestRegularity : AbstractCalculatorTest
    {
        public TestRegularity()
        {
            calc = new Regularity();
        }

        [TestCase(0, LinkUp.None, 1.207)]
        [TestCase(0, LinkUp.Start, 1.5954)]
        [TestCase(0, LinkUp.End, 1.4495)]
        [TestCase(0, LinkUp.Both, 1.707)]
        [TestCase(0, LinkUp.Cycle, 1.8263)]
        public void TestCongenericCalculation(int index, LinkUp linkUp, double value)
        {
            TestCongenericChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 0.6846)]
        [TestCase(0, LinkUp.Start, 0.7253)]
        [TestCase(0, LinkUp.End, 0.6812)]
        [TestCase(0, LinkUp.Both, 0.713)]
        [TestCase(0, LinkUp.Cycle, 0.7917)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}