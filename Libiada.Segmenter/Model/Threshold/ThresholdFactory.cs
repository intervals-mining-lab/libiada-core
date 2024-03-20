namespace Libiada.Segmenter.Model.Threshold;

using System.ComponentModel;

/// <summary>
/// Creates one of available threshold method
/// </summary>
public static class ThresholdFactory
{
    /// <summary>
    /// The make.
    /// </summary>
    /// <param name="threshold">
    /// The threshold.
    /// </param>
    /// <param name="input">
    /// The input.
    /// </param>
    /// <returns>
    /// The <see cref="ThresholdVariator"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if index is unknown.
    /// </exception>
    public static ThresholdVariator Make(Threshold threshold, Input input)
    {
        return threshold switch
        {
            Threshold.Linear => new ThresholdLinear(input.LeftBound, input.RightBound, input.Step),
            Threshold.Dichotomous => new ThresholdDichotomous(input.LeftBound, input.RightBound),
            Threshold.Random => new ThresholdRandom(input.LeftBound, input.RightBound),
            Threshold.Log => null,// Experimental threshold based on any log function
            _ => throw new InvalidEnumArgumentException(nameof(threshold), (int)threshold, typeof(Threshold)),
        };
    }
}
