namespace LibiadaCore.Misc.Iterators
{
    /// <summary>
    /// A simple cut rule.
    /// </summary>
    public class SimpleCutRule : CutRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCutRule"/> class.
        /// </summary>
        /// <param name="chainLength">
        /// Chain length.
        /// </param>
        /// <param name="step">
        /// Shift of iterator.
        /// </param>
        /// <param name="windowLength">
        /// Length of returned subsequence.
        /// </param>
        public SimpleCutRule(int chainLength, int step, int windowLength)
        {
            for (int i = 0; i + windowLength < chainLength; i += step)
            {
                Starts.Add(i);
                Ends.Add(windowLength + i);
            }
        }

        /// <summary>
        /// Creates an iterator for this cut rule.
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
