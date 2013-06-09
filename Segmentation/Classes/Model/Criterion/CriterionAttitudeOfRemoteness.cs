using System;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
    /// <summary>
    /// Provides search for a criterion of integrity the following rule
    /// Average word length is no more than the ratio of log2(Interval(M))/log2(Interval(m))
    /// </summary>
    public class CriterionAttitudeOfRemoteness : Criterion
    {
        private AverageWordLength wordAverageLength = new AverageWordLength();
        private AverageRemoteness remoteness = new AverageRemoteness();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionAttitudeOfRemoteness(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            lastDistortion = Double.MinValue;
            formalismType = Formalism.CRITERION_ATTITUDE_REMOTENESS;
        }


        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double distortion = this.Distortion(chain, alphabet);
            if (Math.Abs(lastDistortion) < Math.Abs(distortion))
            {
                this.chain = (ComplexChain) chain.Clone();
                this.alphabet = (FrequencyDictionary) alphabet.Clone();
                lastDistortion = distortion;
                thresholdToStop.SaveBest();
            }


            return (thresholdToStop.Distance() > ThresholdVariator.PRECISION);
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return (remoteness.Calculate(chain, chain.Anchor)/
                    remoteness.Calculate(chain.Original(), chain.Anchor)) -
                   wordAverageLength.Calculate(chain, chain.Anchor);

        }
    }
}