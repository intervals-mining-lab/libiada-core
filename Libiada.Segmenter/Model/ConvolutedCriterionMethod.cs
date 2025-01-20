namespace Libiada.Segmenter.Model;

using Segmenter.Model.Criterion;

/// <summary>
/// Calculates frequency for convoluted sequence
/// </summary>
public class ConvolutedCriterionMethod : CriterionMethod
{
    /// <summary>
    /// The frequency.
    /// </summary>
    /// <param name="std">
    /// The std.
    /// </param>
    /// <param name="sequenceLength">
    /// The sequence length.
    /// </param>
    /// <param name="windowLength">
    /// The window length.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public override sealed double Frequency(List<int> std, int sequenceLength, int windowLength)
    {
        return Probability(std.Count, sequenceLength - (std.Count * (windowLength - 1)));
    }
}
