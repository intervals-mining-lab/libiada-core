using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.DivizionToAccords
{
    public interface IDataCollector : IEnumerable
    {
        void Add(IteratorStart<Chain, Chain> it, int disp);

        IDataForStd this[Chain chain] { get; }
    }
}