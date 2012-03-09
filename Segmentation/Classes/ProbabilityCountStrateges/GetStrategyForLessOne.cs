using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;

namespace Segmentation.Classes.ProbabilityCountStrateges
{
    public static class GetStrategyForLessOne
    {
        public static Strategy Get(IteratorStart<Chain, Chain> it, int length)
        {
            if(it.ActualPosition()==0)
            {
                return new FirstLessOneStrategy();
            }
           
            return new CommonLessOneStratagy();
        }
    }
}