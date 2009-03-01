using ChainAnalises.Classes.IntervalAnalysis;

namespace ChainAnalises.Classes.DivizionToAccords.ProbabilityCountStrateges
{
    public interface Strategy
    {
        void Calculate(IDataCollector mines_one, Chain chain,int disp);
    }
}