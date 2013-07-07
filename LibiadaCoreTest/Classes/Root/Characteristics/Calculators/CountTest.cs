using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class CountTest : AbstractCalculatorTest
    {
        public CountTest()
        {
            calc = new Count();
        }

        [TestCase(0, LinkUp.None, 3)]
        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 3)]
        [TestCase(0, LinkUp.Cycle, 3)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(0, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 10)]
        [TestCase(0, LinkUp.Start, 10)]
        [TestCase(0, LinkUp.End, 10)]
        [TestCase(0, LinkUp.Both, 10)]
        [TestCase(0, LinkUp.Cycle, 10)]
        public void ChainCalculationTest(int index, LinkUp linkUp, double value)
        {
            ChainCharacteristicTest(index, linkUp, value);
        }
    }
}