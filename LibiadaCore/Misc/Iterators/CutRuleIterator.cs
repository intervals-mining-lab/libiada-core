namespace LibiadaCore.Misc.Iterators
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The cut rule iterator.
    /// </summary>
    public class CutRuleIterator
    {
        /// <summary>
        /// Starts of subsequences.
        /// </summary>
        private readonly List<int> starts;

        /// <summary>
        /// Ends of subsequences.
        /// </summary>
        private readonly List<int> ends;

        /// <summary>
        /// The counter.
        /// </summary>
        private int i = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CutRuleIterator"/> class.
        /// </summary>
        /// <param name="starts">
        /// Starts of subsequences.
        /// </param>
        /// <param name="ends">
        /// Ends of subsequences.
        /// </param>
        public CutRuleIterator(List<int> starts, List<int> ends)
        {
            this.starts = starts;
            this.ends = ends;
        }

        /// <summary>
        /// Moves cursor to the next subsequence.
        /// </summary>
        /// <returns>
        /// true if there is next element.
        /// </returns>
        public bool Next()
        {
            this.i++;
            return (this.starts.Count() > this.i) && (this.ends.Count() > this.i);
        }

        /// <summary>
        /// Returns start position of current element.
        /// </summary>
        /// <returns>
        /// Start position of current subsequence.
        /// </returns>
        public int GetStartPosition()
        {
            return this.starts[this.i];
        }

        /// <summary>
        /// Returns end position of current element.
        /// </summary>
        /// <returns>
        /// End position of current subsequence.
        /// </returns>
        public int GetEndPosition()
        {
            return this.ends[this.i];
        }
    }
}
