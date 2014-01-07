using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class GeometricMeanTest : AbstractCalculatorTest
    {
        public GeometricMeanTest()
        {
            calc = new GeometricMean();
        }

        [TestCase(0, Link.None, 1.7321)]
        [TestCase(0, Link.Start, 2.2894)]
        [TestCase(0, Link.End, 2.0801)]
        [TestCase(0, Link.Both, 2.4495)]
        [TestCase(0, Link.Cycle, 2.6207)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(0, link, value);
        }

        [TestCase(0, Link.None, 2.0339)]
        [TestCase(0, Link.Start, 2.155)]
        [TestCase(0, Link.End, 2.0237)]
        [TestCase(0, Link.Both, 2.1182)]
        [TestCase(0, Link.Cycle, 2.3522)]
        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(0, link, value);
        }
    }
}