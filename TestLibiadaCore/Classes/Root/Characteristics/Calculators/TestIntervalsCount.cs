using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestIntervalsCount : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            IntervalsCount calc = new IntervalsCount();

            TestUniformChainCharacteristic(0, calc, LinkUp.Start,3);
            TestUniformChainCharacteristic(0, calc, LinkUp.End, 3);
            TestUniformChainCharacteristic(0, calc, LinkUp.Both,4);
        }

        [Test]
        public void TestChainCalculation()
        {
            IntervalsCount calc = new IntervalsCount();

            TestChainCharacteristic(0, calc, LinkUp.Start, 10);
            TestChainCharacteristic(0, calc, LinkUp.End, 10);
            TestChainCharacteristic(0, calc, LinkUp.Both, 13);
        }
    }
}