namespace Segmenter.Model.Criterion
{
    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequences;
    using Segmenter.Model.Threshold;

    /// <summary>
    /// The criterion shreder by words.
    /// </summary>
    public class CriterionShrederByWords : Criterion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CriterionShrederByWords"/> class.
        /// </summary>
        /// <param name="threshold">
        /// A rule for handle a threshold value.
        /// </param>
        /// <param name="precision">
        /// The precision.
        /// </param>
        public CriterionShrederByWords(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
        }

        /// <summary>
        /// The state.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return false;
        }

        /// <summary>
        /// The distortion.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return 0;
        }
    }
}