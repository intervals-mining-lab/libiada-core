using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Энтропия словаря по Садовскому.
    ///</summary>
    public class CutLengthVocabularyEntropy : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            CutLength cutLength = new CutLength();
            return Math.Log(pChain.Length - cutLength.Calculate(pChain, Link) + 1, 2);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            CutLength cutLength = new CutLength();
            return Math.Log(pChain.Length - cutLength.Calculate(pChain, Link) + 1, 2);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.CutLengthVocabularyEntropy;
        }
    }
}