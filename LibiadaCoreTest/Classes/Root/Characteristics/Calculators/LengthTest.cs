using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class LengthTest : AbstractCalculatorTest
    {
        public LengthTest()
        {
            calc = new Length();
        }

        [TestCase(0, LinkUp.None, 10)]
        [TestCase(0, LinkUp.Start, 10)]
        [TestCase(0, LinkUp.End, 10)]
        [TestCase(0, LinkUp.Both, 10)]
        [TestCase(0, LinkUp.Cycle, 10)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(index, linkUp, value);
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