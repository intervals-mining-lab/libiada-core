using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestLength : AbstractCalculatorTest
    {
        public TestLength()
        {
            calc = new Length();
        }

        [TestCase(0, LinkUp.None, 10)]
        [TestCase(0, LinkUp.Start, 10)]
        [TestCase(0, LinkUp.End, 10)]
        [TestCase(0, LinkUp.Both, 10)]
        [TestCase(0, LinkUp.Cycle, 10)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            TestUniformChainCharacteristic(index, linkUp, value);
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