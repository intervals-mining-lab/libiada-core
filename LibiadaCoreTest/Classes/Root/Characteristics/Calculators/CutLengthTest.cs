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

        [TestCase(0, Link.None, 4)]
        [TestCase(0, Link.Start, 4)]
        [TestCase(0, Link.End, 4)]
        [TestCase(0, Link.Both, 4)]
        [TestCase(0, Link.Cycle, 4)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 3)]
        [TestCase(0, Link.Start, 3)]
        [TestCase(0, Link.End, 3)]
        [TestCase(0, Link.Both, 3)]
        [TestCase(0, Link.Cycle, 3)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}