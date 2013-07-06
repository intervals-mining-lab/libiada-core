using System;
using System.Collections.Generic;
using Segmentator.Classes.Base.Collectors;
using Segmentator.Classes.Base.Iterators;

namespace Segmentator.Classes.Model.Seekers
{
    /// <summary>
    /// Holds all methods that will use for segmentation with subwords
    /// </summary>
    public abstract class SubwordExtractor : WordExtractor
    {
        protected DataCollector MinusOneEntry = new DataCollector();
        protected DataCollector MinusTwoEntry = new DataCollector();

        /// <summary>
        /// Do not ask any questions, because it realy very fast and redundant is also to the point
        /// Please do learn java performance
        /// </summary>
        /// <param name="it">it only iterator from start</param>
        protected void FindLess(StartIterator it)
        {
            int zero = 0;
            int minLength = 2;
            List<String> accord = it.Current();
            int length = accord.Count;
            int position = it.Position();

            // for less one
            if (position == zero)
            {
                // first less one
                MinusOneEntry.Add(accord.GetRange(0, length - 1), position, 0);
                MinusOneEntry.Add(accord.GetRange(1, length - 1), position, 0);
            }
            else
            {
                // common less one
                MinusOneEntry.Add(accord.GetRange(1, length - 1), position, 0);
            }
            // for less two
            if (length == minLength)
            {
                //do not handle words of length 2
                return;
            }
            if (position == zero)
            {
                // first less two
                MinusTwoEntry.Add(accord.GetRange(1, length - 2), position, 0);
                return;
            }
            int param = it.MaxShifts == it.Shifts ? 0 : 1;

            MinusTwoEntry.Add(accord.GetRange(param, length - 2), position, 0);
        }
    }
}