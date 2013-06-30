using System;
using System.Collections.Generic;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
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
            LastDistortion = Double.MaxValue;

        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double current = Distortion(chain, alphabet);
            if (LastDistortion > current)
            {
                LastDistortion = current;
                Chain = chain.Clone();
                Alphabet = alphabet.Clone();
                ThresholdToStop.SaveBest();
            }
            return (ThresholdToStop.Distance() > ThresholdVariator.PRECISION);
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