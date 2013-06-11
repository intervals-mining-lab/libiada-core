using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestCutLengthVocabularyEntropy
    {
        private ChainsForTests Mother;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            Mother = new ChainsForTests();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCutLengthVocabularyEntropyChain()
        {
            CutLengthVocabularyEntropy cutLengthVocabularyEntropy = new CutLengthVocabularyEntropy();

            Chain testChain = Mother.TestChain();
            CutLength cutLength = new CutLength();
            int Count = (int)(testChain.Length - cutLength.Calculate(testChain, LinkUp.Start) + 1);
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(testChain, LinkUp.Both));
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(testChain, LinkUp.Start));
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(testChain, LinkUp.End));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCutLengthVocabularyEntropyUChain()
        {
            CutLengthVocabularyEntropy cutLengthVocabularyEntropy = new CutLengthVocabularyEntropy();

            UniformChain testChain = Mother.TestUniformChain();
            CutLength cutLength = new CutLength();
            int Count = (int)(testChain.Length - cutLength.Calculate(testChain, LinkUp.Start) + 1);
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(testChain, LinkUp.Both));
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(testChain, LinkUp.Start));
            Assert.AreEqual(Math.Log(Count, 2), cutLengthVocabularyEntropy.Calculate(testChain, LinkUp.End));
        }
    }
}