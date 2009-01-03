using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.PhantomChains;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    class PhantomMessagesCount:ICharacteristicCalculator
    {
        public double Calculate(UniformChain chain, LinkUp Link)
        {
            int count = 1;
            for(int i=0;i<chain.Length;i++)
            {
                MessagePhantom j = chain[i] as MessagePhantom;
                if(j!=null)
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
                if(j!=null)
                {
                    count *= ((MessagePhantom) pChain[i]).power;
                }
            }
            return count;
        }
    }
}
