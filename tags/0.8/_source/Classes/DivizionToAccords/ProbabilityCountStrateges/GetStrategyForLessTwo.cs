using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.DivizionToAccords.ProbabilityCountStrateges;
using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.DivizionToAccords
{
    public static class GetStrategyForLessTwo
    {
        public static Strategy Get(IteratorStart<Chain, Chain> it, int length)
        {
            if (length==2)
            {
                return new NullStrategy();
            }
            if (it.ActualPosition() == 0)
            {
                return new FirstLessTwoStrategy();
            }

            if(it.ActualPosition() == it.MaxStepCount)
            {
                return new LastLessTwoStrategy();
            }

            return new CommonLessTwoStratagy();
        }
    }
}