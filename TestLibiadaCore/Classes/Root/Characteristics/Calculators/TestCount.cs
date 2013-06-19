using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCount : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            Count calc = new Count();

            TestUniformChainCharacteristic(0, calc, LinkUp.Start, 3);
            TestUniformChainCharacteristic(0, calc, LinkUp.End, 3);
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, 3);
        }

        [Test]
        public void TestChainCalculation()
        {
            Count calc = new Count();

            TestChainCharacteristic(0, calc, LinkUp.Start, 10);
            TestChainCharacteristic(0, calc, LinkUp.End, 10);
            TestChainCharacteristic(0, calc, LinkUp.Both, 10);
        }
    }
}