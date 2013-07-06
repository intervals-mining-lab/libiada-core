using System;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using Segmentator.Classes.Base.Collectors;
using Segmentator.Classes.Base.Sequencies;
using Segmentator.Classes.Model.Threshold;

namespace Segmentator.Classes.Model.Criterion
{
    /// <summary>
    /// Provides search for a criterion of integrity the following rule
    /// Average word length is no more than the ratio of log2(Interval(M))/log2(Interval(m))
    /// </summary>
    public class CriterionAttitudeOfRemoteness : Criterion
    {
        private readonly AverageWordLength wordAverageLength = new AverageWordLength();
        private readonly AverageRemoteness remoteness = new AverageRemoteness();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionAttitudeOfRemoteness(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            LastDistortion = Double.MinValue;
        }


        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double distortion = Distortion(chain, alphabet);
            if (Math.Abs(LastDistortion) < Math.Abs(distortion))
            {
                Chain = chain.Clone();
                Alphabet = alphabet.Clone();
                LastDistortion = distortion;
                ThresholdToStop.SaveBest();
            }


            return (ThresholdToStop.Distance() > ThresholdVariator.Precision);
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return (remoteness.Calculate(chain, chain.Anchor)/
                    remoteness.Calculate(chain.Original(), chain.Anchor)) -
                   wordAverageLength.Calculate(chain, chain.Anchor);

        }
    }
}