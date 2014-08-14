namespace Segmenter.Model.Criterion
{
    using System;
    using System.Collections.Generic;

    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequences;
    using Segmenter.Model.Threshold;

    /// <summary>
    /// The criterion of "golden ratio". The basis is the standard law of the golden ratio,
    /// where most of the - power of the alphabet and less - the maximum frequency of the word.
    /// </summary>
    public class CriterionGoldenRatio : Criterion
    {
        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionGoldenRatio(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            Value = double.MaxValue;
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
            double current = Distortion(chain, alphabet);
            if (Value > current)
            {
                Value = current;
                this.chain = chain.Clone();
                this.alphabet = alphabet.Clone();
                ThresholdToStop.SaveBest();
            }

            return ThresholdToStop.Distance > ThresholdVariator.Precision;
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
            double maxFrequency = MaxFrequency(alphabet);
            double power = alphabet.Count;

            double greaterToSmaler = power / maxFrequency;
            double sumToGreater = (power + maxFrequency) / power;

            return Math.Abs(greaterToSmaler - sumToGreater);
        }

        /// <summary>
        /// The max frequency.
        /// </summary>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int MaxFrequency(FrequencyDictionary alphabet)
        {
            int max = 0;
            foreach (List<int> positions in alphabet.GetWordsPositions())
            {
                if (max < positions.Count)
                {
                    max = positions.Count;
                }
            }

            return max;
        }
    }
}