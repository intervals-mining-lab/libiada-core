namespace LibiadaCore.Iterators
{
    using System.Collections.Generic;

    /// <summary>
    /// Cut rule with default starts and ends.
    /// </summary>
    public class DefaultCutRule : CutRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCutRule"/> class.
        /// </summary>
        /// <param name="starts">
        /// Start positions of subsequences.
        /// </param>
        /// <param name="ends">
        /// End positions of subsequences.
        /// </param>
        public DefaultCutRule(List<int> starts, List<int> ends)
        {
            Starts.AddRange(starts);
            Ends.AddRange(ends);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCutRule"/> class with one subsequence.
        /// </summary>
        /// <param name="start">
        /// Start position of subsequence.
        /// </param>
        /// <param name="end">
        /// End position of subsequence.
        /// </param>
        public DefaultCutRule(int start, int end)
        {
            Starts.Add(start);
            Ends.Add(end);
        }

        /// <summary>
        /// Returns iterator for this cut rule.
        /// </summary>
        /// <returns>
        /// The <see cref="CutRuleIterator"/>.
        /// </returns>
        public override CutRuleIterator GetIterator()
        {
            return new CutRuleIterator(Starts, Ends);
        }
    }
}
