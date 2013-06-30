using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCutLengthVocabularyEntropy : AbstractCalculatorTest
    {
        public TestCutLengthVocabularyEntropy()
        {
            calc = new CutLengthVocabularyEntropy();
        }

        [TestCase(0, LinkUp.None, 2.8074)]
        [TestCase(0, LinkUp.Start, 2.8074)]
        [TestCase(0, LinkUp.End, 2.8074)]
        [TestCase(0, LinkUp.Both, 2.8074)]
        [TestCase(0, LinkUp.Cycle, 2.8074)]
        public void TestCongenericCalculation(int index, LinkUp linkUp, double value)
        {
            TestCongenericChainCharacteristic(index, linkUp, value);
        }

        [TestCase(0, LinkUp.None, 3)]
        [TestCase(0, LinkUp.Start, 3)]
        [TestCase(0, LinkUp.End, 3)]
        [TestCase(0, LinkUp.Both, 3)]
        [TestCase(0, LinkUp.Cycle, 3)]
        public void TestCalculation(int index, LinkUp linkUp, double value)
        {
            TestChainCharacteristic(index, linkUp, value);
        }
    }
}