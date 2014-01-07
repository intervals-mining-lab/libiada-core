using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class CutLengthVocabularyEntropyTest : AbstractCalculatorTest
    {
        public CutLengthVocabularyEntropyTest()
        {
            calc = new CutLengthVocabularyEntropy();
        }

        [TestCase(0, Link.None, 2.8074)]
        [TestCase(0, Link.Start, 2.8074)]
        [TestCase(0, Link.End, 2.8074)]
        [TestCase(0, Link.Both, 2.8074)]
        [TestCase(0, Link.Cycle, 2.8074)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }

        [TestCase(0, Link.None, 3)]
        [TestCase(0, Link.Start, 3)]
        [TestCase(0, Link.End, 3)]
        [TestCase(0, Link.Both, 3)]
        [TestCase(0, Link.Cycle, 3)]
        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}