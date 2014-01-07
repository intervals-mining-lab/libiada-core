using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class ProbabilityTest : AbstractCalculatorTest
    {
        public ProbabilityTest()
        {
            calc = new Probability();
        }

        [TestCase(0, Link.None, 0.3)]
        [TestCase(0, Link.Start, 0.3)]
        [TestCase(0, Link.End, 0.3)]
        [TestCase(0, Link.Both, 0.3)]
        [TestCase(0, Link.Cycle, 0.3)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 1)]
        [TestCase(0, Link.Start, 1)]
        [TestCase(0, Link.End, 1)]
        [TestCase(0, Link.Both, 1)]
        [TestCase(0, Link.Cycle, 1)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}