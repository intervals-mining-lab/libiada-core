using System.Collections.Generic;
using Segmentator.Classes.Base;
using Segmentator.Classes.Base.Collectors;
using Segmentator.Classes.Base.Sequencies;
using Segmentator.Classes.Interfaces;
using Segmentator.Classes.Model.Criterion;
using Segmentator.Classes.Model.Seekers;
using Segmentator.Classes.Model.Threshold;

namespace Segmentator.Classes.Model
{
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
            threshold = ThresholdFactory.Make(parameters.GetThresholdMethod(), parameters);
            criterion = CriterionFactory.Make(parameters.GetStopCriterion(), threshold, parameters);
            extractor = WordExtractorFactory.GetSeeker(parameters.seeker);
            balance = parameters.GetBalance();
            windowLen = parameters.GetWindowlength();
            windowDec = parameters.GetWindowdec();
        }

        public new void Slot()
        {
            SimpleChainSplitter chainConvolutor;
            ContentValues par = new ContentValues();
            par.Put(Formalism.Sequence, chain = new ComplexChain(Inputs[0].GetChain()));
            par.Put(Formalism.Alphabet, alphabet = new FrequencyDictionary(chain));

            while (criterion.State(chain, alphabet))
            {
                UpdateParams(par, threshold.Next(criterion));
                chainConvolutor = new SimpleChainSplitter(extractor);
                chain = chainConvolutor.Cut(par);
                alphabet = chainConvolutor.FrequencyDictionary;
            }
            //chain.updateUniforms();
        }

        private void UpdateParams(ContentValues par, double nextThreshold)
        {
            par.Put(Formalism.Sequence, chain = new ComplexChain(Inputs[0].GetChain()));
            //chain.SetName(inputs[0].getChainName());
            par.Put(Parameter.Balance, balance);
            par.Put(Parameter.Window, windowLen);
            par.Put(Parameter.WindowDecrement, windowDec);
            par.Put(Parameter.CurrentThreshold, nextThreshold);
        }

        public new List<MainOutputData> Upload()
        {
            //BuilderResultData builderResultData = new BuilderResultData(chain, alphabet);
            MainOutputData resultUpdate = new MainOutputData();
            resultUpdate.AddInfo((IIdentifiable)criterion, criterion.Value);
            resultUpdate.AddInfo((IIdentifiable)threshold, threshold.Value);
            //ResultDataCreator.saveToFile(resultUpdate);

            Results.Add(resultUpdate);
            return Results;
        }
    }
}