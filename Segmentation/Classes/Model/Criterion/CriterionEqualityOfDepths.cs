using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.TheoryOfSet;
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
        private Depth gamut = new Depth();

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public CriterionEqualityOfDepths(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            lastDistortion = Double.MinValue;
            formalismType = Formalism.CRITERION_EQUALITY_DEPTHS;
        }

        public override bool state(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double currentDistortion = gamut.Calculate(chain, chain.GetAnchor()); //- calculate(gamutDeep, chain);
            if (Math.Abs(currentDistortion) > lastDistortion)
            {
                this.chain = (ComplexChain)chain.Clone();
                this.alphabet = (FrequencyDictionary)alphabet.Clone();
                thresholdToStop.saveBest();
                lastDistortion = currentDistortion;
            }
            return (thresholdToStop.distance() > ThresholdVariator.PRECISION);
        }

        public override double distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return gamut.Calculate(chain.Original(), chain.GetAnchor()); //- gamutDeep.Calculate(chain);
        }
    }
}