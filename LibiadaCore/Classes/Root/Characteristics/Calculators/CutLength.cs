using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Длина обрезания по Садовскому.
    ///</summary>
    public class CutLength : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return CutCommon(pChain);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return CutCommon(pChain);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.CutLength;
        }

        private double CutCommon(BaseChain pChain)
        {
            int i = 1;
            while (i <= pChain.Length)
            {

                if (CheckRecoveryAvaliable(pChain, i))
                {
                    return i;
                }
                i++;
            }
            return pChain.Length;
        }

        private bool CheckRecoveryAvaliable(BaseChain pChain, int i)
        {
            IteratorStart<BaseChain,BaseChain> It = new IteratorStart<BaseChain, BaseChain>(pChain, i, 1);
            Alphabet Temp = new Alphabet();
            while (It.Next())
            {
                if (Temp.Contains(It.Current()))
                {
                    return false;
                }
                Temp.Add(It.Current());
            }
            return true;
        }
    }
}