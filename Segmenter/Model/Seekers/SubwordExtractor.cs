namespace Segmenter.Model.Seekers
{
    using System.Collections.Generic;

    using Segmenter.Base.Collectors;
    using Segmenter.Base.Iterators;

    /// <summary>
    /// Holds all methods that will use for segmentation with subwords
    /// </summary>
    public abstract class SubwordExtractor : WordExtractor
    {
        /// <summary>
        /// The minus one entry.
        /// </summary>
        protected DataCollector minusOneEntry = new DataCollector();

        /// <summary>
        /// The minus two entry.
        /// </summary>
        protected DataCollector minusTwoEntry = new DataCollector();

        /// <summary>
        /// Do not ask any questions, because it really very fast and redundant is also to the point
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
                minusOneEntry.Add(accord.GetRange(0, length - 1), position, 0);
                minusOneEntry.Add(accord.GetRange(1, length - 1), position, 0);
            }
            else
            {
                // common less one
                minusOneEntry.Add(accord.GetRange(1, length - 1), position, 0);
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
                minusTwoEntry.Add(accord.GetRange(1, length - 2), position, 0);
                return;
            }

            int param = it.MaxShifts == it.Shifts ? 0 : 1;

            minusTwoEntry.Add(accord.GetRange(param, length - 2), position, 0);
        }
    }
}
