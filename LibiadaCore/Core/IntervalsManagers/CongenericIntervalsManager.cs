﻿using System.Collections.Generic;

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
            this.building = chain.Building;
            int count = this.building.Count(b => b.Equals(1));
            this.intervals = new int[count - 1];
            this.FillIntervals();
        }

        public CongenericIntervalsManager(Chain chain, int[] intervals, int start, int end)
        {
            this.building = chain.Building;
            this.intervals = intervals;
            Start = start;
            End = end;
        }

        /// <summary>
        /// The fill intervals.
        /// </summary>
        private void FillIntervals()
        {
            // Geting all occurrences of element in building.
            int[] indexes = ArrayManipulator.AllIndexesOf(this.building, 1);

            this.Start = indexes[0] - (-1);

            for (int i = 0; i < this.intervals.Length; i++)
            {
                this.intervals[i] = indexes[i + 1] - indexes[i];
            }

            this.End = this.building.Length - indexes[indexes.Length - 1];
        }
    }
}
