using LibiadaCore.Core.SimpleTypes;
using System.Collections.Generic;
using System.Linq;

namespace LibiadaCore.Core.IntervalsManagers
{
    public class CongenericSeriesManager : ICongenericIntervalsManager
    {

        private List<(int, int)> series = new List<(int, int)>();

        public CongenericSeriesManager(CongenericChain chain)
        {
            series.Add(GetSeries(chain, 0));
            do
            {
                series.Add(GetSeries(chain, series.Last().Item1 + series.Last().Item2));
            }
            while (chain.GetFirstAfter(series.Last().Item1 + series.Last().Item2) != -1); 
        }

        private (int, int) GetSeries(CongenericChain chain, int position)
        {
            int counter = 0;
            int filledPosition = chain.GetFirstAfter(position);
            while (chain[filledPosition + counter] != NullValue.Instance())
            {
                counter++;
            }
            return (filledPosition, counter);
        }

        public int[] GetIntervals(Link link)
        {
            return series.Select(s => s.Item2).ToArray();
        }
    }
}
