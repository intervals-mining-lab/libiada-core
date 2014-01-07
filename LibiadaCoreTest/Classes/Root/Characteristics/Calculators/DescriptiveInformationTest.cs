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

        [TestCase(0, Link.None, 1.4142)]
        [TestCase(0, Link.Start, 1.4445)]
        [TestCase(0, Link.End, 1.4378)]
        [TestCase(0, Link.Both, 1.4446)]
        [TestCase(0, Link.Cycle, 1.435)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 2.8845)]
        [TestCase(0, Link.Start, 2.9917)]
        [TestCase(0, Link.End, 2.9473)]
        [TestCase(0, Link.Both, 2.9865)]
        [TestCase(0, Link.Cycle, 2.971)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}