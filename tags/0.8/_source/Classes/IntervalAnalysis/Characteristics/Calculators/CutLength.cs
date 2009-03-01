using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
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

        private double CutCommon(ChainWithCharacteristic pChain)
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

        private bool CheckRecoveryAvaliable(ChainWithCharacteristic pChain, int i)
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