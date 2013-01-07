using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
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
            formalismType = Formalism.CRITERION_GOLDEN_RATIO;
            lastDistortion = Double.MaxValue;

        }

        public override bool state(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double current = distortion(chain, alphabet);
            if (lastDistortion > current)
            {
                lastDistortion = current;
                this.chain = (ComplexChain)chain.Clone();
                this.alphabet = (FrequencyDictionary)alphabet.Clone();
                thresholdToStop.saveBest();
            }
            return (thresholdToStop.distance() > ThresholdVariator.PRECISION);
        }

        public override double distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double greaterToSmaler = 1;
            double sumToGreater = 1;
            double maxFrequency = this.maxFrequency(alphabet);
            double power = alphabet.power();

            greaterToSmaler = power/maxFrequency;
            sumToGreater = (power + maxFrequency)/power;

            return Math.Abs(greaterToSmaler - sumToGreater);
        }

        private int maxFrequency(FrequencyDictionary alphabet)
        {
            int max = 0;
            foreach (List<int> positions in alphabet.getWordsPositions())
            {
                if (max < positions.Count) max = positions.Count;
            }
            return max;
        }
    }
}