using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class CutLengthTest : AbstractCalculatorTest
    {
        public CutLengthTest()
        {
            calc = new CutLength();
        }

        [TestCase(0, LinkUp.None, 4)]
        [TestCase(0, LinkUp.Start, 4)]
        [TestCase(0, LinkUp.End, 4)]
        [TestCase(0, LinkUp.Both, 4)]
        [TestCase(0, LinkUp.Cycle, 4)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 3)]
        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 3)]
        [TestCase(0, LinkUp.Cycle, 3)]
        public void ChainCalculationTest(int index, LinkUp linkUp, double value)
        {
            ChainCharacteristicTest(index, linkUp, value);
        }
    }
}