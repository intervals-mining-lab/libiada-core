﻿using Segmentator.Classes.Base.Collectors;
using Segmentator.Classes.Base.Sequencies;
using Segmentator.Classes.Interfaces;
using Segmentator.Classes.Model.Threshold;

namespace Segmentator.Classes.Model.Criterion
{
    using LibiadaCore.Core.Characteristics;

    /// <summary>
    /// The criterion of break. Defines the best mode of segmentation.
    /// Allows you to handle how long will the process do something.
    /// </summary>
    public abstract class Criterion: Characteristic, IDefinable
    {
        protected double PrecisionOfDifference;
        protected double LastDistortion;
        protected FrequencyDictionary Alphabet;
        protected new ComplexChain Chain;
        protected readonly ThresholdVariator ThresholdToStop;

        /// <summary>
        /// init
        /// </summary>
        /// <param name="threshold">A rule for handle a threshold value</param>
        /// <param name="precision">additional value to</param>
        public Criterion(ThresholdVariator threshold, double precision)
        {
            ThresholdToStop = threshold;
            PrecisionOfDifference = precision;
        }

        /// <summary>
        /// Returns the state of criterion. True, if everithing is done, false - otherwise
        /// </summary>
        /// <param name="chain">chain</param>
        /// <param name="alphabet">its alphabet</param>
        /// <returns>the state of criterion</returns>
        public abstract bool State(ComplexChain chain, FrequencyDictionary alphabet);

        /// <summary>
        /// Returns distortion between necessary and calculated value
        /// For example between theoretical and practical values
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="alphabet"></param>
        /// <returns>distortion</returns>
        public abstract double Distortion(ComplexChain chain, FrequencyDictionary alphabet);

        /// <summary>
        /// Returns distortion between necessary and calculated value inside of criterion
        /// For example between theoretical and practical values
        /// </summary>
        /// <returns>distortion</returns>
        public double Distortion()
        {
            return Distortion(Chain, Alphabet);
        }

        /// <summary>
        ///  Updates data for computing a new value of the criterion
        /// </summary>
        /// <param name="chain">a new chain</param>
        /// <param name="alphabet">a new alphabet</param>
        public void Renew(ComplexChain chain, FrequencyDictionary alphabet)
        {
            Chain = chain;
            Alphabet = alphabet;
        }

        public new double Value
        {
            get { return LastDistortion; }
        }

        public double GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
}