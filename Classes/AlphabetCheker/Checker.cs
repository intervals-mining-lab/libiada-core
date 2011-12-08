using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.AlphabetCheker
{
    ///<summary>Класс реализующий проверку соответствия заданного
    /// алфавита и заданной цепи
    ///</summary>
    public class Checker
    {
        private readonly AlpabetChains alphabet;

        public Checker(Alphabet alph)
        {
            alphabet = new AlpabetChains();
            foreach (IBaseObject baseObject in alph)
            {
                alphabet.Add(baseObject);
            }
        }

        public bool check(BaseChain chain)
        {
            return Divide(chain) != null;
        }


        public BaseChain Divide(BaseChain chain)
        {
            ActualChain first_chain = new ActualChain(chain);
            Stack stack = new Stack();
            stack.Push(first_chain);
            ArrayList list = alphabet.GetLengthList();
            do
            {
                ActualChain act_chain = (ActualChain) stack.Pop();
                BaseChain chain4check = act_chain.chain;

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    BaseChain word;
                    if (chain4check.Length >= (int)list[i])
                    {
                        IteratorStart<BaseChain, BaseChain> it =
                            new IteratorStart<BaseChain, BaseChain>(chain4check, (int)list[i], 1);
                        it.Next();
                        word = it.Current();
                    }
                    else continue;

                    if (alphabet.Contains(word))
                    {
                        if (chain4check.Length == (int) list[i])//положительный вариант конца поиска решения
                        {
                            act_chain.RemoveLitera((int) list[i]);
                            return act_chain.GetResult();
                        }
                        else
                        {
                            ActualChain new_chain = (ActualChain) act_chain.Clone();
                            new_chain.RemoveLitera((int)list[i]);
                            stack.Push(new_chain);
                        }
                    }
                }
            } while (stack.Count > 0);
            return null;
        }
    }
}