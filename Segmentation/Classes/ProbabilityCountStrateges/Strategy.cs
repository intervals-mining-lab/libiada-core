using ChainAnalises.Classes.IntervalAnalysis;
using Segmentation.Classes.DataCollectors;

namespace Segmentation.Classes.ProbabilityCountStrateges
{
    public interface Strategy
    {
        void Calculate(IDataCollector mines_one, Chain chain,int disp);
    }
}