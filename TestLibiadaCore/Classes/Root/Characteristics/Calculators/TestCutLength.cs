using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCutLength : AbstractCalculatorTest
    {
        [Test]
        public void TestUniformCalculation()
        {
            CutLength calc = new CutLength();

            TestUniformChainCharacteristic(0, calc, LinkUp.Start, 4);
            TestUniformChainCharacteristic(0, calc, LinkUp.End, 4);
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, 4);
        }

        [Test]
        public void TestChainCalculation()
        {
            CutLength calc = new CutLength();

            TestChainCharacteristic(0, calc, LinkUp.Start, 3);
            TestChainCharacteristic(0, calc, LinkUp.End, 3);
            TestChainCharacteristic(0, calc, LinkUp.Both, 3);
        }
    }
}