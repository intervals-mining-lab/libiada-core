namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Энтропия словаря по Садовскому.
    /// </summary>
    public class CutLengthVocabularyEntropy : ICalculator
    {
        private readonly CutLength cutLength = new CutLength();

        public double Calculate(CongenericChain chain, Link link)
        {
            return Math.Log(chain.Length - cutLength.Calculate(chain, link) + 1, 2);
        }

        public double Calculate(Chain chain, Link link)
        {
            
            return Math.Log(chain.Length - cutLength.Calculate(chain, link) + 1, 2);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.CutLengthVocabularyEntropy;
        }
    }
}