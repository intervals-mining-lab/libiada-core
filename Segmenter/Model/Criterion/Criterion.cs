namespace Segmenter.Model.Criterion
{
    using System;

    using Base.Collectors;
    using Base.Sequences;
    using Interfaces;
    using Threshold;

    /// <summary>
    /// The criterion of break. Defines the best mode of segmentation.
    /// Allows you to handle how long will the process do something.
    /// </summary>
    public abstract class Criterion : IDefinable
    {
        /// <summary>
        /// The threshold to stop.
        /// </summary>
        protected readonly ThresholdVariator ThresholdToStop;

        /// <summary>
        /// The precision of difference.
        /// </summary>
        protected double precisionOfDifference;

        /// <summary>
        /// The alphabet.
        /// </summary>
        protected FrequencyDictionary alphabet;

        /// <summary>
        /// The chain.
        /// </summary>
        protected ComplexChain chain;

        /// <summary>
        /// Initializes a new instance of the <see cref="Criterion"/> class.
        /// </summary>
        /// <param name="threshold">
        /// A rule for handling a threshold value.
        /// </param>
        /// <param name="precision">
        /// Additional value to.
        /// </param>
        public Criterion(ThresholdVariator threshold, double precision)
        {
            ThresholdToStop = threshold;
            precisionOfDifference = precision;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public double Value { get; protected set; }

        /// <summary>
        /// Returns the state of criterion. True, if everything is done, false - otherwise.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="alphabet">
        /// Chains alphabet.
        /// </param>
        /// <returns>
        /// The state of criterion.
        /// </returns>
        public abstract bool State(ComplexChain chain, FrequencyDictionary alphabet);

        /// <summary>
        /// Returns distortion between necessary and calculated value.
        /// For example between theoretical and practical values.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public abstract double Distortion(ComplexChain chain, FrequencyDictionary alphabet);

        /// <summary>
        /// Returns distortion between necessary and calculated value inside of criterion.
        /// For example between theoretical and practical values.
        /// </summary>
        /// <returns>
        /// Distortion as <see cref="double"/>.
        /// </returns>
        public double Distortion()
        {
            return Distortion(chain, alphabet);
        }

        /// <summary>
        ///  Updates data for computing a new value of the criterion.
        /// </summary>
        /// <param name="chain">
        /// A new chain.
        /// </param>
        /// <param name="alphabet">
        /// A new alphabet.
        /// </param>
        public void Renew(ComplexChain chain, FrequencyDictionary alphabet)
        {
            this.chain = chain;
            this.alphabet = alphabet;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
