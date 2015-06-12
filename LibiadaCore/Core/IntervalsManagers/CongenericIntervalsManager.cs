namespace LibiadaCore.Core.IntervalsManagers
{
    using System.Linq;

    using LibiadaCore.Misc;

    /// <summary>
    /// The congeneric intervals manager.
    /// </summary>
    public class CongenericIntervalsManager : IntervalsManager
    {
        /// <summary>
        /// The building.
        /// </summary>
        private readonly int[] building;

        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericIntervalsManager"/> class.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        public CongenericIntervalsManager(CongenericChain chain)
        {
            building = chain.Building;
            int count = building.Count(b => b.Equals(1));
            Intervals = new int[count - 1];
            FillIntervals();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CongenericIntervalsManager"/> class.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="intervals">
        /// The intervals.
        /// </param>
        /// <param name="start">
        /// The start.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        public CongenericIntervalsManager(Chain chain, int[] intervals, int start, int end)
        {
            building = chain.Building;
            Intervals = intervals;
            Start = start;
            End = end;
        }

        /// <summary>
        /// The fill intervals.
        /// </summary>
        private void FillIntervals()
        {
            // Geting all occurrences of element in building.
            int[] indexes = ArrayManipulator.AllIndexesOf(building, 1);

            Start = indexes[0] - (-1);

            for (int i = 0; i < Intervals.Length; i++)
            {
                Intervals[i] = indexes[i + 1] - indexes[i];
            }

            End = building.Length - indexes[indexes.Length - 1];
        }
    }
}
