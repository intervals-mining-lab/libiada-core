namespace Segmentator.Model.Criterion
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;

    using Segmentator.Base.Collectors;
    using Segmentator.Base.Sequencies;
    using Segmentator.Model.Threshold;

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
            this.LastDistortion = Double.MinValue;
        }


        public override bool State(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double distortion = this.Distortion(chain, alphabet);
            if (Math.Abs(this.LastDistortion) < Math.Abs(distortion))
            {
                this.Chain = chain.Clone();
                this.Alphabet = alphabet.Clone();
                this.LastDistortion = distortion;
                this.ThresholdToStop.SaveBest();
            }


            return (this.ThresholdToStop.Distance() > ThresholdVariator.Precision);
        }

        public override double Distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return (this.remoteness.Calculate(chain, chain.Anchor)/
                    this.remoteness.Calculate(chain.Original(), chain.Anchor)) -
                   this.wordAverageLength.Calculate(chain, chain.Anchor);

        }
    }
}