using System;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
    /// <summary>
    /// The criterion of minimum regularity.
    /// Allows you to identify the most irregular chain.
    /// </summary>
    public class CriterionMinimumRegularity : Criterion
    {
        private DescriptiveInformation regularity = new DescriptiveInformation();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionMinimumRegularity(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            lastDistortion = Double.MaxValue;
            formalismType = Formalism.CRITERION_MIN_REGULARITY;
        }

        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double distortion = this.Distortion(chain, alphabet);
            if (Math.Abs(lastDistortion) > Math.Abs(distortion))
            {
                this.chain = (ComplexChain)chain.Clone();
                this.alphabet = (FrequencyDictionary)alphabet.Clone();
                lastDistortion = distortion;
                thresholdToStop.SaveBest();
            }
            return (thresholdToStop.Distance() > ThresholdVariator.PRECISION);
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return regularity.Calculate(chain, chain.Anchor);
        }
    }
}