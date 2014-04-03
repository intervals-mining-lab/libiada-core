namespace Segmentator.Model.Criterion
{
    using System;
    using System.Collections.Generic;

    using Segmentator.Base.Collectors;
    using Segmentator.Base.Sequencies;
    using Segmentator.Model.Threshold;

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
            this.LastDistortion = Double.MaxValue;

        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double current = this.Distortion(chain, alphabet);
            if (this.LastDistortion > current)
            {
                this.LastDistortion = current;
                this.Chain = chain.Clone();
                this.Alphabet = alphabet.Clone();
                this.ThresholdToStop.SaveBest();
            }
            return (this.ThresholdToStop.Distance() > ThresholdVariator.Precision);
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double maxFrequency = this.MaxFrequency(alphabet);
            double power = alphabet.Count;

            double greaterToSmaler = power/maxFrequency;
            double sumToGreater = (power + maxFrequency)/power;

            return Math.Abs(greaterToSmaler - sumToGreater);
        }

        private int MaxFrequency(FrequencyDictionary alphabet)
        {
            int max = 0;
            foreach (List<int> positions in alphabet.GetWordsPositions())
            {
                if (max < positions.Count) max = positions.Count;
            }
            return max;
        }
    }
}