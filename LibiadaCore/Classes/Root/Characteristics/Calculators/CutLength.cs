using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Длина обрезания по Садовскому.
    ///</summary>
    public class CutLength : ICalculator
    {
        public double Calculate(CongenericChain chain, Link link)
        {
            return CutCommon(chain);
        }

        public double Calculate(Chain chain, Link link)
        {
            return CutCommon(chain);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.CutLength;
        }

        private double CutCommon(BaseChain chain)
        {
            int i = 1;
            while (i <= chain.Length)
            {

                if (CheckRecoveryAvailable(chain, i))
                {
                    return i;
                }
                i++;
            }
            return chain.Length;
        }

        private bool CheckRecoveryAvailable(BaseChain chain, int i)
        {
            var iterator = new IteratorStart<BaseChain, BaseChain>(chain, i, 1);
            var alphabet = new Alphabet();
            while (iterator.Next())
            {
                if (alphabet.Contains(iterator.Current()))
                {
                    return false;
                }
                alphabet.Add(iterator.Current());
            }
            return true;
        }
    }
}