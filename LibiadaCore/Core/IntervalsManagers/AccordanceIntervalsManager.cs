namespace LibiadaCore.Core.IntervalsManagers
{
    using System.Collections.Generic;

    public class AccordanceIntervalsManager
    {
        public List<int> filteredFirstIntervals = new List<int>();
        public List<int> filteredSecondIntervals = new List<int>();

        public AccordanceIntervalsManager(CongenericChain firstChain, CongenericChain secondChain)
        {
            int[] firstIntervals = firstChain.GetIntervals(Link.End);
            int[] secondIntervals = secondChain.GetIntervals(Link.End);
            
            int j = 1;
            
            for (int i = 1; i < firstChain.OccurrencesCount - 1; i++)
            {
                int firstPosition = firstChain.GetOccurrence(i);
                int nextFirstPosition = firstChain.GetOccurrence(i + 1) == -1 ? firstChain.GetLength() : firstChain.GetOccurrence(i + 1);
                for (; j < secondChain.OccurrencesCount - 1; j++)
                {
                    int secondOccurence = secondChain.GetOccurrence(j);
                    if (secondOccurence >= firstPosition && secondOccurence < nextFirstPosition)
                    {
                        filteredFirstIntervals.Add(firstIntervals[i - 1]);
                        filteredSecondIntervals.Add(secondIntervals[j - 1]);
                        break;
                    }
                }
            }
        }

    }
}