using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class IntervalsCountTest : AbstractCalculatorTest
    {
        public IntervalsCountTest()
        {
            calc = new IntervalsCount();
        }

        [TestCase(0, Link.None, 2)]
        [TestCase(0, Link.Start, 3)]
        [TestCase(0, Link.End, 3)]
        [TestCase(0, Link.Both, 4)]
        [TestCase(0, Link.Cycle, 3)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 7)]
        [TestCase(0, Link.Start, 10)]
        [TestCase(0, Link.End, 10)]
        [TestCase(0, Link.Both, 13)]
        [TestCase(0, Link.Cycle, 10)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}