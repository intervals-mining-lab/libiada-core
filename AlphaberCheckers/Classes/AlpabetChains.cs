using System.Collections;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;

namespace AlphaberCheckers.Classes
{
    public class AlpabetChains : Alphabet
    {
        public override int  Add(IBaseObject item)
        {
            BaseChain temp =  item as BaseChain;
            if (temp == null)
            {
                temp = new BaseChain(1);
                temp.Add(item, 0);
            }
            return base.Add(temp);
        }

        public ArrayList GetLengthList()
        {
            SortedList list = new SortedList();
            for(int i=0 ; i<power; i++)
            {
                int l = ((BaseChain) this[i]).Length;
                if(list.ContainsKey(l)) continue;
                list.Add(l,l);
            }
            return new ArrayList(list.Keys);
        }
    }
}
