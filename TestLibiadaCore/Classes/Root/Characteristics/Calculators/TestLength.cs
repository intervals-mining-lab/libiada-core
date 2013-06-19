using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestLength : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            Length calc = new Length();
            TestUniformChainCharacteristic(0, calc, LinkUp.Start, 10);
            TestUniformChainCharacteristic(0, calc, LinkUp.End, 10);
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, 10);
        }

        [Test]
        public void TestChainCalculation()
        {
            Length calc = new Length();

            TestChainCharacteristic(0, calc, LinkUp.Start, 10);
            TestChainCharacteristic(0, calc, LinkUp.End, 10);
            TestChainCharacteristic(0, calc, LinkUp.Both, 10);

        }
    }
}