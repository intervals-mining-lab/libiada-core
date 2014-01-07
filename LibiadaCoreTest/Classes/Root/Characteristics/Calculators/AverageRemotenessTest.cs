using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class AverageRemotenessTest : AbstractCalculatorTest
    {
        public AverageRemotenessTest()
        {
            calc = new AverageRemoteness();
        }

        [TestCase(0, Link.None, 0.7925)]
        [TestCase(0, Link.Start, 1.195)]
        [TestCase(0, Link.End, 1.0567)]
        [TestCase(0, Link.Both, 1.2925)]
        [TestCase(0, Link.Cycle, 1.39)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 1.0242)]
        [TestCase(0, Link.Start, 1.1077)]
        [TestCase(0, Link.End, 1.017)]
        [TestCase(0, Link.Both, 1.0828)]
        [TestCase(0, Link.Cycle, 1.234)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}