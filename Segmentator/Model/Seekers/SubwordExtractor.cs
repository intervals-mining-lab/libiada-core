﻿namespace Segmentator.Model.Seekers
{
    using System.Collections.Generic;

    using Segmentator.Base.Collectors;
    using Segmentator.Base.Iterators;

    /// <summary>
    /// Holds all methods that will use for segmentation with subwords
    /// </summary>
    public abstract class SubwordExtractor : WordExtractor
    {
        protected DataCollector minusOneEntry = new DataCollector();
        protected DataCollector minusTwoEntry = new DataCollector();

        /// <summary>
        /// Do not ask any questions, because it realy very fast and redundant is also to the point
        /// Please do learn java performance
        /// </summary>
        /// <param name="it">it only iterator from start</param>
        protected void FindLess(StartIterator it)
        {
            int zero = 0;
            int minLength = 2;
            List<string> accord = it.Current();
            int length = accord.Count;
            int position = it.Position();

            // for less one
            if (position == zero)
            {
                // first less one
                this.minusOneEntry.Add(accord.GetRange(0, length - 1), position, 0);
                this.minusOneEntry.Add(accord.GetRange(1, length - 1), position, 0);
            }
            else
            {
                // common less one
                this.minusOneEntry.Add(accord.GetRange(1, length - 1), position, 0);
            }

            // for less two
            if (length == minLength)
            {
                // do not handle words of length 2
                return;
            }

            if (position == zero)
            {
                // first less two
                this.minusTwoEntry.Add(accord.GetRange(1, length - 2), position, 0);
                return;
            }

            int param = it.MaxShifts == it.Shifts ? 0 : 1;

            this.minusTwoEntry.Add(accord.GetRange(param, length - 2), position, 0);
        }
    }
}