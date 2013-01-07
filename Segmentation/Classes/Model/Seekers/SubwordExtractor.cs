using System;
using System.Collections.Generic;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Iterators;

namespace Segmentation.Classes.Model.Seekers
{
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
        protected void findLess(StartIterator it)
        {
            int zero = 0;
            int minLength = 2;
            List<String> accord = it.current();
            int length = accord.Count;
            int position = it.position();

            // for less one
            if (position == zero)
            {
                // first less one
                minusOneEntry.add(accord.GetRange(0, length - 1), position, 0);
                minusOneEntry.add(accord.GetRange(1, length - 1), position, 0);
            }
            else
            {
                // common less one
                minusOneEntry.add(accord.GetRange(1, length - 1), position, 0);
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
                minusTwoEntry.add(accord.GetRange(1, length - 2), position, 0);
                return;
            }
            if (it.getMaxShifts() == it.shifts())
            {
                // last less two
                minusTwoEntry.add(accord.GetRange(0, length - 2), position, 0);
            }
            else
            {
                // common less two
                minusTwoEntry.add(accord.GetRange(1, length - 2), position, 0);
            }
        }
    }
}