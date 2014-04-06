namespace Segmenter.Model.Criterion
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;

    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequencies;
    using Segmenter.Model.Threshold;

    /// <summary>
    /// Criterion "Equaty of depths". Goal to find a chain with the same amount of information
    /// </summary>
    public class CriterionEqualityOfDepths : Criterion
    {
        private readonly Depth depth = new Depth();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionEqualityOfDepths(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            this.lastDistortion = double.MinValue;
        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double currentDistortion = this.depth.Calculate(chain, chain.Anchor); // - calculate(gamutDeep, chain);
            if (Math.Abs(currentDistortion) > this.lastDistortion)
            {
                this.chain = chain.Clone();
                this.alphabet = alphabet.Clone();
                this.ThresholdToStop.SaveBest();
                this.lastDistortion = currentDistortion;
            }

            return this.ThresholdToStop.Distance > ThresholdVariator.Precision;
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return this.depth.Calculate(chain.Original(), chain.Anchor); // - gamutDeep.Calculate(chain);
        }
    }
}