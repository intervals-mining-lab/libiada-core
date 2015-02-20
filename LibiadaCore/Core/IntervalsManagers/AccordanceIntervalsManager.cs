using System.Collections.Generic;

namespace LibiadaCore.Core.IntervalsManagers
{
    public class AccordanceIntervalsManager
    {
        /// <summary>
        /// The first chain.
        /// </summary>
        private readonly CongenericChain FirstChain;

        /// <summary>
        /// The second chain.
        /// </summary>
        private readonly CongenericChain SecondChain;

        /// <summary>
        /// The chains length.
        /// </summary>
        public readonly int Length;

        /// <summary>
        /// First accordance  intervals.
        /// </summary>
        public readonly List<int> FilteredFirstIntervals = new List<int>();

        /// <summary>
        /// Second accordance intervals.
        /// </summary>
        public readonly List<int> FilteredSecondIntervals = new List<int>();

        /// <summary>
        /// First element occurrences count.
        /// </summary>
        public readonly int FirstOccurrencesCount;

        /// <summary>
        /// Second element occurrences count.
        /// </summary>
        public readonly int SecondOccurrencesCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryIntervalsManager"/> class.
        /// </summary>
        /// <param name="firstChain">
        /// The first chain.
        /// </param>
        /// <param name="secondChain">
        /// The second chain.
        /// </param>
        public AccordanceIntervalsManager(CongenericChain firstChain, CongenericChain secondChain)
        {
            FirstChain = firstChain;
            SecondChain = secondChain;
            Length = firstChain.GetLength();
            FirstOccurrencesCount = firstChain.OccurrencesCount;
            SecondOccurrencesCount = secondChain.OccurrencesCount;

            FillAccordanceIntervals();
        }

        /// <summary>
        /// The fill accordance intervals.
        /// </summary>
        private void FillAccordanceIntervals()
        {
            int[] firstIntervals = FirstChain.GetIntervals(Link.End);
            int[] secondIntervals = SecondChain.GetIntervals(Link.End);

            int j = 1;

            for (int i = 1; i <= FirstOccurrencesCount; i++)
            {
                int firstPosition = FirstChain.GetOccurrence(i);
                int nextFirstPosition = FirstChain.GetOccurrence(i + 1) == -1 ? Length : FirstChain.GetOccurrence(i + 1);
                for (; j <= SecondChain.OccurrencesCount; j++)
                {
                    int secondOccurrence = SecondChain.GetOccurrence(j);
                    if (secondOccurrence >= firstPosition && secondOccurrence < nextFirstPosition)
                    {
                        FilteredFirstIntervals.Add(firstIntervals[i - 1]);
                        FilteredSecondIntervals.Add(secondIntervals[j - 1]);
                        break;
                    }
                }
            }
        } 
    }
}