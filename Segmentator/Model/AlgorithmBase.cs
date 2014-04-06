namespace Segmentator.Model
{
    using System.Collections.Generic;

    using Segmentator.Base;
    using Segmentator.Base.Collectors;
    using Segmentator.Base.Sequencies;
    using Segmentator.Interfaces;
    using Segmentator.Model.Criterion;
    using Segmentator.Model.Seekers;
    using Segmentator.Model.Threshold;

    /// <summary>
    /// The base algorithm has a model of segmentation
    /// based on the difference between actual and expected frequency of occurrence of subwords
    /// </summary>
    public class AlgorithmBase : Algorithm
    {
        private ComplexChain chain;
        private FrequencyDictionary alphabet;
        private ThresholdVariator threshold;
        private WordExtractor extractor;
        private Criterion.Criterion criterion;
        private int balance;
        private int windowLen;
        private int windowDec;

        public AlgorithmBase()
        {
        }

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

        public new void Slot()
        {
            SimpleChainSplitter chainConvolutor;
            ContentValues par = new ContentValues();
            par.Put(Formalism.Sequence, this.chain = new ComplexChain(this.inputs[0].Chain));
            par.Put(Formalism.Alphabet, this.alphabet = new FrequencyDictionary(this.chain));

            while (this.criterion.State(this.chain, this.alphabet))
            {
                this.UpdateParams(par, this.threshold.Next(this.criterion));
                chainConvolutor = new SimpleChainSplitter(this.extractor);
                this.chain = chainConvolutor.Cut(par);
                this.alphabet = chainConvolutor.FrequencyDictionary;
            }
        }

        public new List<MainOutputData> Upload()
        {
            MainOutputData resultUpdate = new MainOutputData();
            resultUpdate.AddInfo((IIdentifiable)this.criterion, this.criterion.Value);
            resultUpdate.AddInfo((IIdentifiable)this.threshold, this.threshold.Value);

            this.results.Add(resultUpdate);
            return this.results;
        }

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