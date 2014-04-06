namespace Segmentator.Model.Criterion
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;

    using Segmentator.Base.Collectors;
    using Segmentator.Base.Sequencies;
    using Segmentator.Model.Threshold;

    /// <summary>
    /// The criterion of minimum regularity.
    /// Allows you to identify the most irregular chain.
    /// </summary>
    public class CriterionMinimumRegularity : Criterion
    {
        private readonly DescriptiveInformation regularity = new DescriptiveInformation();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionMinimumRegularity(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            this.lastDistortion = double.MaxValue;
        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double distortion = this.Distortion(chain, alphabet);
            if (Math.Abs(this.lastDistortion) > Math.Abs(distortion))
            {
                this.chain = chain.Clone();
                this.alphabet = alphabet.Clone();
                this.lastDistortion = distortion;
                this.ThresholdToStop.SaveBest();
            }

            return this.ThresholdToStop.Distance > ThresholdVariator.Precision;
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return this.regularity.Calculate(chain, chain.Anchor);
        }
    }
}