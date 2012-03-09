using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;
using Segmentation.Classes.DataCollectors;

namespace Segmentation.Classes.ProbabilityCountStrateges
{
    public class FirstLessTwoStrategy : Strategy
    {
        public void Calculate(IDataCollector mines_one, Chain chain, int disp)
        {
            IteratorStart<Chain, Chain> it = new IteratorStart<Chain, Chain>(chain, chain.Length - 2, 1);
            it.Next();
            it.Next();
            mines_one.Add(it, disp);
            it.Next();
            mines_one.Add(it, disp);
        }
    }
}