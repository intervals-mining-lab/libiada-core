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
        public void TestUniformCalculation()
        {
            CutLengthVocabularyEntropy calc = new CutLengthVocabularyEntropy();

            CutLength cutLength = new CutLength();
            int Count = (int)(uniformChains[0].Length - cutLength.Calculate(uniformChains[0], LinkUp.Start) + 1);
            TestUniformChainCharacteristic(0, calc, LinkUp.Start, Math.Log(Count, 2));
            TestUniformChainCharacteristic(0, calc, LinkUp.End, Math.Log(Count, 2));
            TestUniformChainCharacteristic(0, calc, LinkUp.Both, Math.Log(Count, 2));
        }

        [Test]
        public void TestChainCalculation()
        {
            CutLengthVocabularyEntropy cutLengthVocabularyEntropy = new CutLengthVocabularyEntropy();

            CutLength calc = new CutLength();
            int Count = (int)(Chains[0].Length - calc.Calculate(Chains[0], LinkUp.Start) + 1);
            TestChainCharacteristic(0, calc, LinkUp.Start, Math.Log(Count, 2));
            TestChainCharacteristic(0, calc, LinkUp.End, Math.Log(Count, 2));
            TestChainCharacteristic(0, calc, LinkUp.Both, Math.Log(Count, 2));
        }
    }
}