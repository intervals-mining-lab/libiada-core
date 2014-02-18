namespace LibiadaCore.Classes.Misc.Iterators
{
    /// <summary>
    /// The from fix start cut rule.
    /// </summary>
    public class CutRuleWithFixedStart : CutRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CutRuleWithFixedStart"/> class.
        /// </summary>
        /// <param name="length">
        /// Length of full chain.
        /// </param>
        /// <param name="step">
        /// The step.
        /// </param>
        public CutRuleWithFixedStart(int length, int step)
        {
            for (int i = step; i <= length; i += step)
            {
                Starts.Add(0);
                Ends.Add(i < length ? i : length);
            }
        }

        /// <summary>
        /// The get iterator.
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
