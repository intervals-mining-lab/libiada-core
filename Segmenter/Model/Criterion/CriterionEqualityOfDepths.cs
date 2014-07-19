namespace Segmenter.Model.Criterion
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;

    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequences;
    using Segmenter.Model.Threshold;

    /// <summary>
    /// Criterion "Equality of depths". Goal to find a chain with the same amount of information
    /// </summary>
    public class CriterionEqualityOfDepths : Criterion
    {
        /// <summary>
        /// The depth.
        /// </summary>
        private readonly Depth depth = new Depth();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionEqualityOfDepths(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            this.Value = double.MinValue;
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
            double currentDistortion = this.depth.Calculate(chain, chain.Anchor); // - calculate(gamutDeep, chain);
            if (Math.Abs(currentDistortion) > this.Value)
            {
                this.chain = chain.Clone();
                this.alphabet = alphabet.Clone();
                this.ThresholdToStop.SaveBest();
                this.Value = currentDistortion;
            }

            return this.ThresholdToStop.Distance > ThresholdVariator.Precision;
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
            return this.depth.Calculate(chain.Original(), chain.Anchor); // - gamutDeep.Calculate(chain);
        }
    }
}