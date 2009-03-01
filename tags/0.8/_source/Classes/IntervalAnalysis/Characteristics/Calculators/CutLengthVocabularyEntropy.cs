using System;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    public class CutLengthVocabularyEntropy : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return CutLengthVocabularyEntropyCommon(pChain, Link);
        }

        private double CutLengthVocabularyEntropyCommon(ChainWithCharacteristic pChain, LinkUp Link)
        {
            return Math.Log(pChain.Length - pChain.GetCharacteristic(Link, CharacteristicsFactory.CutLength) + 1, 2);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return CutLengthVocabularyEntropyCommon(pChain, Link);
        }
    }
}