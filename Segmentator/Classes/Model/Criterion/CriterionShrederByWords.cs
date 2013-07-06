using Segmentator.Classes.Base.Collectors;
using Segmentator.Classes.Base.Sequencies;
using Segmentator.Classes.Model.Threshold;

namespace Segmentator.Classes.Model.Criterion
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