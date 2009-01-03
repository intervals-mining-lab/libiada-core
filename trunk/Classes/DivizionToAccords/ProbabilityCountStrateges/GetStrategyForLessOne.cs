using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.DivizionToAccords.ProbabilityCountStrateges;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.DivizionToAccords
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