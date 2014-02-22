namespace AlphabetCheckers.Classes
{
    using System.Collections;

    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.TheoryOfSet;

    /// <summary>
    /// ����� ����������� �������� ������������ ���������
    /// �������� � �������� ����
    /// </summary>
    public class Checker
    {
        /// <summary>
        /// The alphabet.
        /// </summary>
        private readonly ChainsAlphabet alphabet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Checker"/> class.
        /// </summary>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        public Checker(Alphabet alphabet)
        {
            this.alphabet = new ChainsAlphabet();
            foreach (IBaseObject baseObject in alphabet)
            {
                alphabet.Add(baseObject);
            }
        }

        /// <summary>
        /// The check.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Check(BaseChain chain)
        {
            return Divide(chain) != null;
        }

        /// <summary>
        /// The divide.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <returns>
        /// The <see cref="BaseChain"/>.
        /// </returns>
        public BaseChain Divide(BaseChain chain)
        {
            var firstChain = new ActualChain(chain);
            var stack = new Stack();
            stack.Push(firstChain);
            ArrayList list = alphabet.GetLengthList();
            do
            {
                var actChain = (ActualChain)stack.Pop();
                BaseChain chain4Check = actChain.Source;

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    BaseChain word;
                    if (chain4Check.Length >= (int)list[i])
                    {
                        var it = new IteratorStart<BaseChain, BaseChain>(chain4Check, (int)list[i], 1);
                        it.Next();
                        word = it.Current();
                    }
                    else
                    {
                        continue;
                    }

                    if (alphabet.Contains(word))
                    {
                        // ������������� ������� ����� ������ �������
                        if (chain4Check.Length == (int)list[i])
                        {
                            actChain.RemoveCharacter((int)list[i]);
                            return actChain.GetResult();
                        }

                        var newChain = (ActualChain)actChain.Clone();
                        newChain.RemoveCharacter((int)list[i]);
                        stack.Push(newChain);
                    }
                }
            }
            while (stack.Count > 0);
            return null;
        }
    }
}