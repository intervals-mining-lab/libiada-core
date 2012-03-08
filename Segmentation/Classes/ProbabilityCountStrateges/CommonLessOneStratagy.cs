using Segmentation.Classes.DataCollectors;

namespace Segmentation.Classes.ProbabilityCountStrateges
{
    internal class CommonLessOneStratagy : Strategy
    {
        public void Calculate(IDataCollector mines_one, Chain chain, int disp)
        {
            IteratorStart<Chain, Chain> it = new IteratorStart<Chain, Chain>(chain, chain.Length - 1, 1);
            it.Next();
            it.Next();
            mines_one.Add(it, disp);
        }
    }
}