using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class RegularityTest : AbstractCalculatorTest
    {
        public RegularityTest()
        {
            calc = new Regularity();
        }

        [TestCase(0, LinkUp.None, 1.2248)]
        [TestCase(0, LinkUp.Start, 1.5849)]
        [TestCase(0, LinkUp.End, 1.4467)]
        [TestCase(0, LinkUp.Both, 1.6956)]
        [TestCase(0, LinkUp.Cycle, 1.8263)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 0.7051)]
        [TestCase(0, LinkUp.Start, 0.7203)]
        [TestCase(0, LinkUp.End, 0.6866)]
        [TestCase(0, LinkUp.Both, 0.70926)]
        [TestCase(0, LinkUp.Cycle, 0.7917)]
        public void ChainCalculationTest(int index, LinkUp linkUp, double value)
        {
            ChainCharacteristicTest(index, linkUp, value);
        }
    }
}