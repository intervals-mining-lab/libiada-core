using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;

namespace AlphaberCheckers.Classes
{
    class ActualChain:ICloneable 
    {
        public BaseChain chain;
        protected BaseChain result_chain;
        protected int actual_length;
        

        public  ActualChain(BaseChain chain)
        {
            this.chain = (BaseChain) chain.Clone();
            actual_length = 0;
            result_chain = new BaseChain(chain.Length);
        }

        public void RemoveLitera(int length)
        {
            if (chain.Length == length)
            {
                result_chain.Add(chain, actual_length);
                chain = null;
            }
            else
            {
                IteratorStart<BaseChain, BaseChain> it1 =
                    new IteratorStart<BaseChain, BaseChain>(chain, length, 1);
                it1.Next();
                result_chain.Add(it1.Current(), actual_length);
                IteratorEnd<BaseChain, BaseChain> it2 =
                    new IteratorEnd<BaseChain, BaseChain>(chain, chain.Length - length, 1);
                it2.Next();
                chain = it2.Current();
            }
            actual_length++;
        }

        public BaseChain GetResult()
        {
            IteratorStart<BaseChain, BaseChain> it = 
                new IteratorStart<BaseChain, BaseChain>(result_chain, actual_length, 1);
            it.Next();
            return it.Current();
        }

        public object Clone()
        {
            ActualChain new_chain = new ActualChain((BaseChain) chain.Clone());
            new_chain.result_chain = (BaseChain) result_chain.Clone();
            new_chain.actual_length = actual_length;
            return new_chain;
        }
    }
}