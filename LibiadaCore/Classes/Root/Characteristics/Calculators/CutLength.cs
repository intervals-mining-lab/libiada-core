using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Длина обрезания по Садовскому.
    ///</summary>
    public class CutLength : ICharacteristicCalculator
    {
        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            return CutCommon(chain);
        }

        public double Calculate(Chain chain, LinkUp linkUp)
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

                if (CheckRecoveryAvaliable(chain, i))
                {
                    return i;
                }
                i++;
            }
            return chain.Length;
        }

        private bool CheckRecoveryAvaliable(BaseChain chain, int i)
        {
            IteratorStart<BaseChain,BaseChain> iterator = new IteratorStart<BaseChain, BaseChain>(chain, i, 1);
            Alphabet alphabet = new Alphabet();
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