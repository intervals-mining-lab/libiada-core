using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class ArithmeticMeanTest : AbstractCalculatorTest
    {
        public ArithmeticMeanTest()
        {
            calc = new ArithmeticMean();
        }

        [TestCase(0, LinkUp.None, 2)]
        [TestCase(0, LinkUp.Start, 2.6667)]
        [TestCase(0, LinkUp.End, 2.3333)]
        [TestCase(0, LinkUp.Both, 2.75)]
        [TestCase(0, LinkUp.Cycle, 3.3333)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 2.4286)]
        [TestCase(0, LinkUp.Start, 2.6)]
        [TestCase(0, LinkUp.End, 2.4)]
        [TestCase(0, LinkUp.Both, 2.5385)]
        [TestCase(0, LinkUp.Cycle, 3)]
        public void ChainCalculationTest(int index, LinkUp linkUp, double value)
        {
            ChainCharacteristicTest(0, linkUp, value);
        }
    }
}