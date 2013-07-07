using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class PeriodicityTest : AbstractCalculatorTest
    {
        public PeriodicityTest()
        {
            calc = new Periodicity();
        }

        [TestCase(0, LinkUp.None, 0.8661)]
        [TestCase(0, LinkUp.Start, 0.8585)]
        [TestCase(0, LinkUp.End, 0.8915)]
        [TestCase(0, LinkUp.Both, 0.8907)]
        [TestCase(0, LinkUp.Cycle, 0.7862)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 0.8375)]
        [TestCase(0, LinkUp.Start, 0.8288)]
        [TestCase(0, LinkUp.End, 0.8432)]
        [TestCase(0, LinkUp.Both, 0.8344)]
        [TestCase(0, LinkUp.Cycle, 0.7841)]
        public void ChainCalculationTest(int index, LinkUp linkUp, double value)
        {
            ChainCharacteristicTest(index, linkUp, value);
        }
    }
}