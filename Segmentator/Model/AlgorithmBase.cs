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
            this.threshold = ThresholdFactory.Make(parameters.GetThresholdMethod(), parameters);
            this.criterion = CriterionFactory.Make(parameters.GetStopCriterion(), this.threshold, parameters);
            this.extractor = WordExtractorFactory.GetSeeker(parameters.seeker);
            this.balance = parameters.GetBalance();
            this.windowLen = parameters.GetWindowlength();
            this.windowDec = parameters.GetWindowdec();
        }

        public new void Slot()
        {
            SimpleChainSplitter chainConvolutor;
            ContentValues par = new ContentValues();
            par.Put(Formalism.Sequence, this.chain = new ComplexChain(this.Inputs[0].GetChain()));
            par.Put(Formalism.Alphabet, this.alphabet = new FrequencyDictionary(this.chain));

            while (this.criterion.State(this.chain, this.alphabet))
            {
                this.UpdateParams(par, this.threshold.Next(this.criterion));
                chainConvolutor = new SimpleChainSplitter(this.extractor);
                this.chain = chainConvolutor.Cut(par);
                this.alphabet = chainConvolutor.FrequencyDictionary;
            }
            //chain.updateUniforms();
        }

        private void UpdateParams(ContentValues par, double nextThreshold)
        {
            par.Put(Formalism.Sequence, this.chain = new ComplexChain(this.Inputs[0].GetChain()));
            //chain.SetName(inputs[0].getChainName());
            par.Put(Parameter.Balance, this.balance);
            par.Put(Parameter.Window, this.windowLen);
            par.Put(Parameter.WindowDecrement, this.windowDec);
            par.Put(Parameter.CurrentThreshold, nextThreshold);
        }

        public new List<MainOutputData> Upload()
        {
            //BuilderResultData builderResultData = new BuilderResultData(chain, alphabet);
            MainOutputData resultUpdate = new MainOutputData();
            resultUpdate.AddInfo((IIdentifiable)this.criterion, this.criterion.Value);
            resultUpdate.AddInfo((IIdentifiable)this.threshold, this.threshold.Value);
            //ResultDataCreator.saveToFile(resultUpdate);

            this.Results.Add(resultUpdate);
            return this.Results;
        }
    }
}