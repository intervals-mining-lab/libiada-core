﻿namespace LibiadaCore.Core.ArrangementManagers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The congeneric series manager.
    /// </summary>
    public class SeriesManager : IArrangementManager
    {
        /// <summary>
        /// The series.
        /// </summary>
        private List<(int, int)> series;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesManager"/> class.
        /// </summary>
        public SeriesManager()
        {
        }

        /// <summary>
        /// Initializes series manager with given sequence.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        public void Initialize(CongenericChain chain)
        {
            series = new List<(int, int)>();
            for (int i = 1; i <= chain.OccurrencesCount; i++)
            {
                series.Add(GetSeries(chain, i));
            }
        }

        /// <summary>
        /// Gets series from congeneric sequence.
        /// </summary>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="T:int[]"/>.
        /// </returns>
        public int[] GetArrangement(Link link)
        {
            if (series == null)
            {
                throw new Exception("Series manager is not initialized");
            }

            return series.Select(s => s.Item2).ToArray();
        }

        /// <summary>
        /// Gets series from given occurrence.
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
    }
}