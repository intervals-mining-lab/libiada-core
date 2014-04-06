namespace Segmenter.Model
{
    using System.Collections.Generic;

    using Segmenter.Model.Criterion;

    /// <summary>
    /// Calculates frequency for not convoluted chain
    /// </summary>
    public class NotConvolutedCriterionMethod : CriterionMethod
    {
        /// <summary>
        /// The frequency.
        /// </summary>
        /// <param name="std">
        /// The std.
        /// </param>
        /// <param name="chainLength">
        /// The chain length.
        /// </param>
        /// <param name="windowLength">
        /// The window length.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public override sealed double Frequency(List<int> std, int chainLength, int windowLength)
        {
            return this.Probability(std.Count, chainLength);
        }
    }
}