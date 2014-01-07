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

        [TestCase(0, Link.None, 1.2248)]
        [TestCase(0, Link.Start, 1.5849)]
        [TestCase(0, Link.End, 1.4467)]
        [TestCase(0, Link.Both, 1.6956)]
        [TestCase(0, Link.Cycle, 1.8263)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 0.7051)]
        [TestCase(0, Link.Start, 0.7203)]
        [TestCase(0, Link.End, 0.6866)]
        [TestCase(0, Link.Both, 0.70926)]
        [TestCase(0, Link.Cycle, 0.7917)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}