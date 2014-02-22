namespace AlphabetCheckers.Classes
{
    using System.Collections;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.TheoryOfSet;

    /// <summary>
    /// The alpabet chains.
    /// </summary>
    public class ChainsAlphabet : Alphabet
    {
        /// <summary>
        /// Addes chain to alphabet.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// <see cref="int"/>.
        /// </returns>
        public override int Add(IBaseObject item)
        {
            var temp = item as BaseChain;
            if (temp == null)
            {
                temp = new BaseChain(1);
                temp.Add(item, 0);
            }

            return base.Add(temp);
        }

        /// <summary>
        /// The get length list.
        /// </summary>
        /// <returns>
        /// The <see cref="ArrayList"/>.
        /// </returns>
        public ArrayList GetLengthList()
        {
            var list = new SortedList();
            for (int i = 0; i < Cardinality; i++)
            {
                int l = ((BaseChain)this[i]).Length;
                if (list.ContainsKey(l))
                {
                    continue;
                }

                list.Add(l, l);
            }

            return new ArrayList(list.Keys);
        }
    }
}
