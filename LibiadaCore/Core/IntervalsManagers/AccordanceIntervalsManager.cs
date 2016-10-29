namespace LibiadaCore.Core.IntervalsManagers
{
    using System.Collections.Generic;

    /// <summary>
    /// The accordance intervals manager.
    /// </summary>
    public class AccordanceIntervalsManager
    {
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
        /// The first chain.
        /// </summary>
        private readonly CongenericChain firstChain;

        /// <summary>
        /// The second chain.
        /// </summary>
        private readonly CongenericChain secondChain;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccordanceIntervalsManager"/> class.
        /// </summary>
        /// <param name="firstChain">
        /// The first chain.
        /// </param>
        /// <param name="secondChain">
        /// The second chain.
        /// </param>
        public AccordanceIntervalsManager(CongenericChain firstChain, CongenericChain secondChain)
        {
            this.firstChain = firstChain;
            this.secondChain = secondChain;
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
            int[] firstIntervals = firstChain.GetIntervals(Link.End);
            int[] secondIntervals = secondChain.GetIntervals(Link.End);

            for (int i = 1; i <= FirstOccurrencesCount; i++)
            {
                int firstPosition = firstChain.GetOccurrence(i);
                int nextFirstPosition = firstChain.GetOccurrence(i + 1) == -1 ? Length : firstChain.GetOccurrence(i + 1);
                for (int j = 1; j <= secondChain.OccurrencesCount; j++)
                {
                    int secondOccurrence = secondChain.GetOccurrence(j);
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
