using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    [TestFixture]
    public class TestCutLengthVocabularyEntropy : AbstractCalculatorTest
    {
        [Test]
        public void TestCutLengthVocabularyEntropyChain()
        {
            CutLengthVocabularyEntropy cutLengthVocabularyEntropy = new CutLengthVocabularyEntropy();

            CutLength cutLength = new CutLength();
            int Count = (int)(Chains[0].Length - cutLength.Calculate(Chains[0], LinkUp.Start) + 1);
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(Chains[0], LinkUp.Both));
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(Chains[0], LinkUp.Start));
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(Chains[0], LinkUp.End));
        }

        [Test]
        public void TestCutLengthVocabularyEntropyUChain()
        {
            CutLengthVocabularyEntropy cutLengthVocabularyEntropy = new CutLengthVocabularyEntropy();

            CutLength cutLength = new CutLength();
            int Count = (int)(uniformChains[0].Length - cutLength.Calculate(uniformChains[0], LinkUp.Start) + 1);
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(uniformChains[0], LinkUp.Both));
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(uniformChains[0], LinkUp.Start));
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(uniformChains[0], LinkUp.End));
        }
    }
}