using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestProbability : AbstractCalculatorTest
    {
        public TestProbability()
        {
            calc = new Probability();
        }

        [TestCase(0, LinkUp.None, 0.3)]
        [TestCase(0, LinkUp.Start, 0.3)]
        [TestCase(0, LinkUp.End, 0.3)]
        [TestCase(0, LinkUp.Both, 0.3)]
        [TestCase(0, LinkUp.Cycle, 0.3)]
        public void TestCongenericCalculation(int index, LinkUp linkUp, double value)
        {
            TestCongenericChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 1)]
        [TestCase(0, LinkUp.Start, 1)]
        [TestCase(0, LinkUp.End, 1)]
        [TestCase(0, LinkUp.Both, 1)]
        [TestCase(0, LinkUp.Cycle, 1)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}