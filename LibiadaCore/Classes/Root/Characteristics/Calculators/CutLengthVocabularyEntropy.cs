using System;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Энтропия словаря по Садовскому.
    ///</summary>
    public class CutLengthVocabularyEntropy : ICalculator
    {
        private readonly CutLength cutLength = new CutLength();

        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            return Math.Log(chain.Length - cutLength.Calculate(chain, linkUp) + 1, 2);
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            
            return Math.Log(chain.Length - cutLength.Calculate(chain, linkUp) + 1, 2);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.CutLengthVocabularyEntropy;
        }
    }
}