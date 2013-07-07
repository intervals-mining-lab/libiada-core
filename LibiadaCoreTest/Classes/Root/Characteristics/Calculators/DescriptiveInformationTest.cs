using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class DescriptiveInformationTest : AbstractCalculatorTest
    {
        public DescriptiveInformationTest()
        {
            calc = new DescriptiveInformation();
        }

        [TestCase(0, LinkUp.None, 1.435)]
        [TestCase(0, LinkUp.Start, 1.435)]
        [TestCase(0, LinkUp.End, 1.435)]
        [TestCase(0, LinkUp.Both, 1.435)]
        [TestCase(0, LinkUp.Cycle, 1.435)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 2.971)]
        [TestCase(0, LinkUp.Start, 2.971)]
        [TestCase(0, LinkUp.End, 2.971)]
        [TestCase(0, LinkUp.Both, 2.971)]
        [TestCase(0, LinkUp.Cycle, 2.971)]
        public void ChainCalculationTest(int index, LinkUp linkUp, double value)
        {
            ChainCharacteristicTest(index, linkUp, value);
        }
    }
}