namespace Segmenter.Model
{
    using System.Collections.Generic;

    using Segmenter.Base;
    using Segmenter.Base.Collectors;
    using Segmenter.Base.Sequences;
    using Segmenter.Interfaces;
    using Segmenter.Model.Criterion;
    using Segmenter.Model.Seekers;
    using Segmenter.Model.Threshold;

    /// <summary>
    /// The base algorithm has a model of segmentation
    /// based on the difference between actual and expected frequency of occurrence of subwords
    /// </summary>
    public class AlgorithmBase : Algorithm
    {
        /// <summary>
        /// The chain.
        /// </summary>
        private ComplexChain chain;

        /// <summary>
        /// The alphabet.
        /// </summary>
        private FrequencyDictionary alphabet;

        /// <summary>
        /// The threshold.
        /// </summary>
        private ThresholdVariator threshold;

        /// <summary>
        /// The extractor.
        /// </summary>
        private WordExtractor extractor;

        /// <summary>
        /// The criterion.
        /// </summary>
        private Criterion.Criterion criterion;

        /// <summary>
        /// The balance.
        /// </summary>
        private int balance;

        /// <summary>
        /// The window len.
        /// </summary>
        private int windowLen;

        /// <summary>
        /// The window dec.
        /// </summary>
        private int windowDec;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlgorithmBase"/> class.
        /// </summary>
        public AlgorithmBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlgorithmBase"/> class.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        public AlgorithmBase(Input parameters)
            : base(parameters)
        {
            this.threshold = ThresholdFactory.Make(parameters.ThresholdMethod, parameters);
            this.criterion = CriterionFactory.Make(parameters.StopCriterion, this.threshold, parameters);
            this.extractor = WordExtractorFactory.GetSeeker(parameters.Seeker);
            this.balance = parameters.Balance;
            this.windowLen = parameters.Windowlength;
            this.windowDec = parameters.WindowDecrement;
        }

        /// <summary>
        /// The slot.
        /// </summary>
        public new void Slot()
        {
            var par = new ContentValues();
            par.Put(Formalism.Sequence, this.chain = new ComplexChain(this.inputs[0].Chain));
            par.Put(Formalism.Alphabet, this.alphabet = new FrequencyDictionary(this.chain));

            while (this.criterion.State(this.chain, this.alphabet))
            {
                this.UpdateParams(par, this.threshold.Next(this.criterion));
                var chainSplitter = new SimpleChainSplitter(this.extractor);
                this.chain = chainSplitter.Cut(par);
                this.alphabet = chainSplitter.FrequencyDictionary;
            }
        }

        /// <summary>
        /// The upload.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public new List<MainOutputData> Upload()
        {
            var resultUpdate = new MainOutputData();
            resultUpdate.AddInfo((IIdentifiable)this.criterion, this.criterion.Value);
            resultUpdate.AddInfo((IIdentifiable)this.threshold, this.threshold.Value);

            this.results.Add(resultUpdate);
            return this.results;
        }

        /// <summary>
        /// The update parameters.
        /// </summary>
        /// <param name="par">
        /// The par.
        /// </param>
        /// <param name="nextThreshold">
        /// The next threshold.
        /// </param>
        private void UpdateParams(ContentValues par, double nextThreshold)
        {
            par.Put(Formalism.Sequence, this.chain = new ComplexChain(this.inputs[0].Chain));
            par.Put(Parameter.Balance, this.balance);
            par.Put(Parameter.Window, this.windowLen);
            par.Put(Parameter.WindowDecrement, this.windowDec);
            par.Put(Parameter.CurrentThreshold, nextThreshold);
        }
    }
}