namespace Libiada.Core.Iterators;

/// <summary>
/// The simple cut rule with shifted start.
/// </summary>
public class SimpleCutRuleWithShiftedStart : CutRule
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleCutRuleWithShiftedStart"/> class.
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
    /// <param name="begin">
    /// Shift of start.
    /// </param>
    public SimpleCutRuleWithShiftedStart(int chainLength, int step, int windowLength, int begin)
    {
        for (int i = begin; i + windowLength <= chainLength; i += step)
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
