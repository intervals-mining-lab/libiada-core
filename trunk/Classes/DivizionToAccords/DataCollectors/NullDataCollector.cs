using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.DivizionToAccords
{
    internal class NullDataCollector : IDataCollector
    {
        public void Add(IteratorStart<Chain, Chain> it, int disp)
        {
            
        }

        public IDataForStd this[Chain chain]
        {
            get
            {
                return new NullDataForStd();
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (new ArrayList()).GetEnumerator();
        }
    }
}