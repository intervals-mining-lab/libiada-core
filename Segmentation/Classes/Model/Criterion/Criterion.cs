using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Interfaces;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
    /// <summary>
    /// The criterion of break. Defines the best mode of segmentation.
    /// Allows you to handle how long will the process do something.
    /// </summary>
    public abstract class Criterion: Characteristic, IDefinable
    {
        protected double precisionOfDifference;
        protected double lastDistortion;
        protected FrequencyDictionary alphabet;
        protected ComplexChain chain;
        protected ThresholdVariator thresholdToStop;
        protected Formalism formalismType;

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public Criterion(ThresholdVariator threshold, double precision)
        {
            this.thresholdToStop = threshold;
            this.precisionOfDifference = precision;
        }

        /// <summary>
        /// Returns the state of criterion. True, if everithing is done, false - otherwise
        /// </summary>
        /// <param name="chain">chain</param>
        /// <param name="alphabet">its alphabet</param>
        /// <returns>the state of criterion</returns>
        public abstract bool state(ComplexChain chain, FrequencyDictionary alphabet);

        /// <summary>
        /// Returns distortion between necessary and calculated value
        /// For example between theoretical and practical values
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="alphabet"></param>
        /// <returns>distortion</returns>
        public abstract double distortion(ComplexChain chain, FrequencyDictionary alphabet);

        /// <summary>
        /// Returns distortion between necessary and calculated value inside of criterion
        /// For example between theoretical and practical values
        /// </summary>
        /// <returns>distortion</returns>
        public double distortion()
        {
            return distortion(chain, alphabet);
        }

        /// <summary>
        ///  Updates data for computing a new value of the criterion
        /// </summary>
        /// <param name="chain">a new chain</param>
        /// <param name="alphabet">a new alphabet</param>
        public void renew(ComplexChain chain, FrequencyDictionary alphabet)
        {
            this.chain = chain;
            this.alphabet = alphabet;
        }


        public Chain getChain()
        {
            return chain;
        }

        public String getName()
        {
            return Formalism.GetName(typeof(Formalism), formalismType);
        }

        public double getValue()
        {
            return lastDistortion;
        }
    }
}