﻿namespace Segmenter.Model.Criterion
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;

    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequences;
    using Segmenter.Model.Threshold;

    /// <summary>
    /// Provides search for a criterion of integrity the following rule
    /// Average word length is no more than the ratio of log2(Interval(M))/log2(Interval(m))
    /// </summary>
    public class CriterionAttitudeOfRemoteness : Criterion
    {
        /// <summary>
        /// The word average length.
        /// </summary>
        private readonly AverageWordLength wordAverageLength = new AverageWordLength();

        /// <summary>
        /// The remoteness.
        /// </summary>
        private readonly AverageRemoteness remoteness = new AverageRemoteness();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionAttitudeOfRemoteness(ThresholdVariator threshold, double precision)
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
            double distortion = this.Distortion(chain, alphabet);
            if (Math.Abs(this.Value) < Math.Abs(distortion))
            {
                this.chain = chain.Clone();
                this.alphabet = alphabet.Clone();
                this.Value = distortion;
                this.ThresholdToStop.SaveBest();
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
            return (this.remoteness.Calculate(chain, chain.Anchor)
                    / this.remoteness.Calculate(chain.Original(), chain.Anchor))
                   - this.wordAverageLength.Calculate(chain, chain.Anchor);
        }
    }
}