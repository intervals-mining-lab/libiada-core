using System.Collections;
using System.Collections.Specialized;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using Segmentation.Classes.AuxiliaryClasses;

namespace Segmentation.Classes.DataCollectors
{
    public class DataCollector : IDataCollector
    {
        private ListDictionary dictionary = new ListDictionary();

        public void Add(IteratorStart<Chain, Chain> it, int disp)
        {
            Chain temp = it.Current();
            if (!dictionary.Contains(temp))
            {
                dictionary.Add(temp, new DataForStd());
            }
            ((IDataForStd)dictionary[temp]).AddPosition(it.ActualPosition()+disp);
        }

        public IDataForStd this[Chain chain]
        {
            get { return (IDataForStd) dictionary[chain]; }
        }

        public IEnumerator GetEnumerator()
        {
            return dictionary.GetEnumerator();

        }
    }
}