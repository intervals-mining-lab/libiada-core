namespace Libiada.Segmenter.Model.Threshold;

/// <summary>
/// The threshold random.
/// </summary>
public class ThresholdRandom : ThresholdVariator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThresholdRandom"/> class.
    /// </summary>
    /// <param name="leftBound">
    /// The left bound of threshold.
    /// </param>
    /// <param name="rightBound">
    /// The right bound of threshold.
    /// </param>
    public ThresholdRandom(double leftBound, double rightBound)
        : base(leftBound, rightBound)
    {
    }

    /// <summary>
    /// The next.
    /// </summary>
    /// <param name="criterion">
    /// The criterion.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public override double Next(Criterion.Criterion criterion)
    {
        return 0;
    }
}
