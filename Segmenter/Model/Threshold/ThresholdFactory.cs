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
        /// <param name="index">
        /// The index.
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
        public static ThresholdVariator Make(int index, Input input)
        {
            switch (index)
            {
                case 0: 
                    return new ThresholdLinear(input.LeftBound, input.RightBound, input.Step);
                case 1: 
                    return new ThresholdDichotomous(input.LeftBound, input.RightBound);
                case 2: 
                    return new ThresholdRandom(input.LeftBound, input.RightBound);
                case 3: 
                    return null; // Experimental threshold based on any log function
                default:
                    throw new ArgumentException("Unknown index", "index");
            }
        } 
    }
}
