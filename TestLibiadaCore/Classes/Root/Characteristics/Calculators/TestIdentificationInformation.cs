using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestIdentificationInformation : AbstractCalculatorTest
    {
        public TestIdentificationInformation()
        {
            calc = new IdentificationInformation();
        }

        [TestCase(0, LinkUp.None, 0.5211)]
        [TestCase(0, LinkUp.Start, 0.5211)]
        [TestCase(0, LinkUp.End, 0.5211)]
        [TestCase(0, LinkUp.Both, 0.5211)]
        [TestCase(0, LinkUp.Cycle, 0.5211)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            TestUniformChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 1.571)]
        [TestCase(0, LinkUp.Start, 1.571)]
        [TestCase(0, LinkUp.End, 1.571)]
        [TestCase(0, LinkUp.Both, 1.571)]
        [TestCase(0, LinkUp.Cycle, 1.571)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}