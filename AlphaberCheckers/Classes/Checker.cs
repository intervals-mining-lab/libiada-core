using System.Collections;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;

namespace AlphaberCheckers.Classes
{
    ///<summary>
    /// Класс реализующий проверку соответствия заданного
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

        public bool Check(BaseChain chain)
        {
            return Divide(chain) != null;
        }


        public BaseChain Divide(BaseChain chain)
        {
            ActualChain firstChain = new ActualChain(chain);
            Stack stack = new Stack();
            stack.Push(firstChain);
            ArrayList list = alphabet.GetLengthList();
            do
            {
                ActualChain actChain = (ActualChain) stack.Pop();
                BaseChain chain4Check = actChain.Chain;

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    BaseChain word;
                    if (chain4Check.Length >= (int)list[i])
                    {
                        IteratorStart<BaseChain, BaseChain> it =
                            new IteratorStart<BaseChain, BaseChain>(chain4Check, (int)list[i], 1);
                        it.Next();
                        word = it.Current();
                    }
                    else continue;

                    if (alphabet.Contains(word))
                    {
                        if (chain4Check.Length == (int) list[i])//положительный вариант конца поиска решения
                        {
                            actChain.RemoveLitera((int) list[i]);
                            return actChain.GetResult();
                        }
                        ActualChain newChain = (ActualChain) actChain.Clone();
                        newChain.RemoveLitera((int)list[i]);
                        stack.Push(newChain);
                    }
                }
            } while (stack.Count > 0);
            return null;
        }
    }
}