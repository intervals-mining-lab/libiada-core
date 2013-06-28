using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;
using LibiadaCore.Classes.Root;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestVolume : AbstractCalculatorTest
    {
        [TestCase(0, LinkUp.None, 3)]
        [TestCase(0, LinkUp.Start, 12)]
        [TestCase(0, LinkUp.End, 9)]
        [TestCase(0, LinkUp.Both, 36)]
        [TestCase(0, LinkUp.Cycle, 18)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            Volume calc = new Volume();
            TestUniformChainCharacteristic(index, calc, linkUp, value);
        }
    }
}