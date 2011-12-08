using System.Collections;
using System.Collections.Specialized;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.DivizionToAccords
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