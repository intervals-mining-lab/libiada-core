﻿using System;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
    /// <summary>
    /// Criterion "Equaty of depths". Goal to find a chain with the same amount of information
    /// </summary>
    public class CriterionEqualityOfDepths : Criterion
    {
        //private GamutDeep gamutDeep = new GamutDeep();
        private readonly Depth depth = new Depth();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionEqualityOfDepths(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            LastDistortion = Double.MinValue;
        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double currentDistortion = depth.Calculate(chain, chain.Anchor); //- calculate(gamutDeep, chain);
            if (Math.Abs(currentDistortion) > LastDistortion)
            {
                Chain = chain.Clone();
                Alphabet = alphabet.Clone();
                ThresholdToStop.SaveBest();
                LastDistortion = currentDistortion;
            }
            return (ThresholdToStop.Distance() > ThresholdVariator.PRECISION);
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return depth.Calculate(chain.Original(), chain.Anchor); //- gamutDeep.Calculate(chain);
        }
    }
}