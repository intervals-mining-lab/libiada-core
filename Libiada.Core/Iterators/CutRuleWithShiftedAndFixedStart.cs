namespace Libiada.Core.Iterators;

/// <summary>
/// Cut rule with fixed and shifted start.
/// </summary>
public class CutRuleWithShiftedAndFixedStart : CutRule
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CutRuleWithShiftedAndFixedStart"/> class.
    /// </summary>
    /// <param name="length">
    /// Length of source chain.
    /// </param>
    /// <param name="step">
    /// Size of shift in elements.
    /// </param>
    /// <param name="startShift">
    /// Shift of the start in elements.
    /// </param>
    public CutRuleWithShiftedAndFixedStart(int length, int step, int startShift)
    {
        for (int i = startShift + step; i <= length; i += step)
        {
            Starts.Add(startShift);
            Ends.Add(i < length ? i : length);
        }
    }

    /// <summary>
    /// Returns iterator.
    /// </summary>
    /// <returns>
    /// The <see cref="CutRuleIterator"/>.
    /// </returns>
    public override CutRuleIterator GetIterator()
    {
        return new CutRuleIterator(Starts, Ends);
    }
}
