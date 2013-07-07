using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class IdentificationInformationTest : AbstractCalculatorTest
    {
        public IdentificationInformationTest()
        {
            calc = new IdentificationInformation();
        }

        [TestCase(0, LinkUp.None, 0.5211)]
        [TestCase(0, LinkUp.Start, 0.5211)]
        [TestCase(0, LinkUp.End, 0.5211)]
        [TestCase(0, LinkUp.Both, 0.5211)]
        [TestCase(0, LinkUp.Cycle, 0.5211)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 1.571)]
        [TestCase(0, LinkUp.Start, 1.571)]
        [TestCase(0, LinkUp.End, 1.571)]
        [TestCase(0, LinkUp.Both, 1.571)]
        [TestCase(0, LinkUp.Cycle, 1.571)]
        public void ChainCalculationTest(int index, LinkUp linkUp, double value)
        {
            ChainCharacteristicTest(index, linkUp, value);
        }
    }
}