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

        [TestCase(0, LinkUp.None, 1.7321)]
        [TestCase(0, LinkUp.Start, 2.2894)]
        [TestCase(0, LinkUp.End, 2.0801)]
        [TestCase(0, LinkUp.Both, 2.4495)]
        [TestCase(0, LinkUp.Cycle, 2.6207)]
        public void CongenericCalculationTest(int index, LinkUp linkUp, double value)
        {
            CongenericChainCharacteristicTest(0, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 2.0339)]
        [TestCase(0, LinkUp.Start, 2.155)]
        [TestCase(0, LinkUp.End, 2.0237)]
        [TestCase(0, LinkUp.Both, 2.1182)]
        [TestCase(0, LinkUp.Cycle, 2.3522)]
        public void CalculationTest(int index, LinkUp linkUp, double value)
        {
            ChainCharacteristicTest(0, linkUp, value);
        }
    }
}