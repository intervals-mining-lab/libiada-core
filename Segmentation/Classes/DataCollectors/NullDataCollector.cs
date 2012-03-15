using System.Collections;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using Segmentation.Classes.AuxiliaryClasses;

namespace Segmentation.Classes.DataCollectors
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