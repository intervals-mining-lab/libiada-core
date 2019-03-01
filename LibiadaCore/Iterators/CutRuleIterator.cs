namespace LibiadaCore.Iterators
{
    using System.Collections.Generic;

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
        private int index = -1;

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
            index++;
            return (starts.Count > index) && (ends.Count > index);
        }

        /// <summary>
        /// Returns start position of current element.
        /// </summary>
        /// <returns>
        /// Start position of current subsequence.
        /// </returns>
        public int GetStartPosition()
        {
            return starts[index];
        }

        /// <summary>
        /// Returns end position of current element.
        /// </summary>
        /// <returns>
        /// End position of current subsequence.
        /// </returns>
        public int GetEndPosition()
        {
            return ends[index];
        }
    }
}
