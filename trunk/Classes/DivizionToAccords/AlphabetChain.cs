using System;
using System.Collections;
using System.Text;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.DivizionToAccords
{
    public class AlphabetChain : Alphabet
    {
        public override int Add(IBaseObject item)
        {
            Chain temp = item as Chain;
            if (temp == null)
            {
                temp = new Chain(1);
                temp.Add(item, 0);
            }
            return base.Add(temp);
        }

        public ArrayList GetLengthList()
        {
            SortedList list = new SortedList();
            for (int i = 0; i < power; i++)
            {
                int l = ((Chain)this[i]).Length;
                if (list.ContainsKey(l)) continue;
                list.Add(l, l);
            }
            return new ArrayList(list.Keys);
        }
    }
}
