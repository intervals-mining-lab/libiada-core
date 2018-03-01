namespace LibiadaCore.Core.IntervalsManagers
{
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The congeneric series manager.
    /// </summary>
    public class CongenericSeriesManager : ICongenericIntervalsManager
    {
        /// <summary>
        /// The series.
        /// </summary>
        private readonly List<(int, int)> series = new List<(int, int)>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericSeriesManager"/> class.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        public CongenericSeriesManager(CongenericChain chain)
        {
            for (int i = 1; i <= chain.OccurrencesCount; i++)
            {
                series.Add(GetSeries(chain, i));
            }
        }

        /// <summary>
        /// The get series.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="occurrence">
        /// Occurrence index of the element.
        /// </param>
        /// <returns>
        /// The <see cref="T:(int, int)"/>.
        /// </returns>
        private (int, int) GetSeries(CongenericChain chain, int occurrence)
        {
            int counter = 0;
            int position = chain.GetOccurrence(occurrence);
            while (!chain[position + counter].Equals(NullValue.Instance()))
            {
                counter++;
            }

            return (position, counter);
        }

        /// <summary>
        /// The get intervals.
        /// </summary>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="int[]"/>.
        /// </returns>
        public int[] GetIntervals(Link link)
        {
            return series.Select(s => s.Item2).ToArray();
        }
    }
}
