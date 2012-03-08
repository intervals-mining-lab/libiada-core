using System.Collections;
using Segmentation.Classes.AuxiliaryClasses;

namespace Segmentation.Classes.DataCollectors
{
    public interface IDataCollector : IEnumerable
    {
        void Add(IteratorStart<Chain, Chain> it, int disp);

        IDataForStd this[Chain chain] { get; }
    }
}