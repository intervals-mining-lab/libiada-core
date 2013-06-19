using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestAlphabetPower : AbstractCalculatorTest
    {
        [TestCase(0, LinkUp.Start, 1)]
        [TestCase(0, LinkUp.End, 1)]
        [TestCase(0, LinkUp.Both, 1)]
        public void TestUniformCalculation(int index, LinkUp linkUp, double value)
        {
            AlphabetPower alphabetPower = new AlphabetPower();

            TestUniformChainCharacteristic(index, alphabetPower, linkUp, value);
        }

        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 3)]
        public void TestChainCalculation(int index, LinkUp linkUp, double value)
        {
            AlphabetPower alphabetPower = new AlphabetPower();

            TestChainCharacteristic(index, alphabetPower, linkUp, value);
        }
    }
}