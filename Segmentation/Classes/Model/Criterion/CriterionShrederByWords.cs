﻿using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
    public class CriterionShrederByWords : Criterion
    {
        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionShrederByWords(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return false;
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return 0;
        }
    }
}