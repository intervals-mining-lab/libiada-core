using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using ChainAnalises.Classes.PhantomChains;

namespace libiada.Classes.IntervalAnalysis.Characteristics.Calculators
{
    internal class PhantomMessagesCount : ICharacteristicCalculator
    {
        #region ICharacteristicCalculator Members

        public double Calculate(UniformChain chain, LinkUp Link)
        {
            int count = 1;
            for (int i = 0; i < chain.Length; i++)
            {
                MessagePhantom j = chain[i] as MessagePhantom;
                if (j != null)
                {
                    count *= ((MessagePhantom) chain[i]).power;
                }
            }
            return count;
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            int count = 1;
            for (int i = 0; i < pChain.Length; i++)
            {
                MessagePhantom j = pChain[i] as MessagePhantom;
                if (j != null)
                {
                    count *= ((MessagePhantom) pChain[i]).power;
                }
            }
            return count;
        }

        #endregion
    }
    }