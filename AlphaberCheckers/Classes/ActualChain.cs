using System;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;

namespace AlphaberCheckers.Classes
{
    class ActualChain:ICloneable 
    {
        public BaseChain Chain;
        protected BaseChain ResultChain;
        protected int ActualLength;
        

        public  ActualChain(BaseChain chain)
        {
            Chain = (BaseChain) chain.Clone();
            ActualLength = 0;
            ResultChain = new BaseChain(chain.Length);
        }

        public void RemoveLitera(int length)
        {
            if (Chain.Length == length)
            {
                ResultChain.Add(Chain, ActualLength);
                Chain = null;
            }
            else
            {
                IteratorStart<BaseChain, BaseChain> it1 =
                    new IteratorStart<BaseChain, BaseChain>(Chain, length, 1);
                it1.Next();
                ResultChain.Add(it1.Current(), ActualLength);
                IteratorEnd<BaseChain, BaseChain> it2 =
                    new IteratorEnd<BaseChain, BaseChain>(Chain, Chain.Length - length, 1);
                it2.Next();
                Chain = it2.Current();
            }
            ActualLength++;
        }

        public BaseChain GetResult()
        {
            IteratorStart<BaseChain, BaseChain> it = 
                new IteratorStart<BaseChain, BaseChain>(ResultChain, ActualLength, 1);
            it.Next();
            return it.Current();
        }

        public object Clone()
        {
            ActualChain newChain = new ActualChain((BaseChain) Chain.Clone())
                {
                    ResultChain = (BaseChain) ResultChain.Clone(),
                    ActualLength = ActualLength
                };
            return newChain;
        }
    }
}