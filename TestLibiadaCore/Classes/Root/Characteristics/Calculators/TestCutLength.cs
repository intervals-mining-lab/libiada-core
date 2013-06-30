using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCutLength : AbstractCalculatorTest
    {
        public TestCutLength()
        {
            calc = new CutLength();
        }

        [TestCase(0, LinkUp.None, 4)]
        [TestCase(0, LinkUp.Start, 4)]
        [TestCase(0, LinkUp.End, 4)]
        [TestCase(0, LinkUp.Both, 4)]
        [TestCase(0, LinkUp.Cycle, 4)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            TestUniformChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 3)]
        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 3)]
        [TestCase(0, LinkUp.Cycle, 3)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}