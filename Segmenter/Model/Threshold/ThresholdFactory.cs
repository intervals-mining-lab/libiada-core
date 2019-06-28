using System.ComponentModel;

namespace Segmenter.Model.Threshold
{
    using System;

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
            switch (threshold)
            {
                case Threshold.Linear:
                    return new ThresholdLinear(input.LeftBound, input.RightBound, input.Step);
                case Threshold.Dichotomous:
                    return new ThresholdDichotomous(input.LeftBound, input.RightBound);
                case Threshold.Random:
                    return new ThresholdRandom(input.LeftBound, input.RightBound);
                case Threshold.Log:
                    return null; // Experimental threshold based on any log function
                default:
                    throw new InvalidEnumArgumentException(nameof(threshold), (int)threshold, typeof(Threshold));
            }
        }
    }
}
