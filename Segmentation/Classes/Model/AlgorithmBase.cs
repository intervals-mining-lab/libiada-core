using System.Collections.Generic;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Interfaces;
using Segmentation.Classes.Model.Criterion;
using Segmentation.Classes.Model.Seekers;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model
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
            formalismType = Formalism.ALGORITHM_BASE;
        }


        public AlgorithmBase(Input parameters)
            : base(parameters)
        {
            threshold = ThresholdFactory.Make(parameters.GetThresholdMethod(), parameters);
            criterion = CriterionFactory.make(parameters.GetStopCriterion(), threshold, parameters);
            extractor = WordExtractorFactory.GetSeeker(parameters.seeker);
            balance = parameters.GetBalance();
            windowLen = parameters.GetWindowlength();
            windowDec = parameters.GetWindowdec();
        }

        public void Slot()
        {
            SimpleChainSplitter chainConvolutor = null;
            ContentValues par = new ContentValues();
            par.Put(Formalism.SEQUENCE, chain = new ComplexChain(inputs[0].GetChain()));
            par.Put(Formalism.ALPHABET, alphabet = new FrequencyDictionary(chain));

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
            par.Put(Formalism.SEQUENCE, chain = new ComplexChain(inputs[0].GetChain()));
            //chain.SetName(inputs[0].getChainName());
            par.Put(Parameter.BALANCE, balance);
            par.Put(Parameter.WINDOW, windowLen);
            par.Put(Parameter.WINDOW_DECREMENT, windowDec);
            par.Put(Parameter.CURRENT_THRESHOLD, nextThreshold);
        }

        public List<MainOutputData> Upload()
        {
            //BuilderResultData builderResultData = new BuilderResultData(chain, alphabet);
            MainOutputData resultUpdate = new MainOutputData();
            resultUpdate.addInfo((IIdentifiable)criterion, criterion.Value);
            resultUpdate.addInfo((IIdentifiable)threshold, threshold.Value);
            //ResultDataCreator.saveToFile(resultUpdate);

            results.Add(resultUpdate);
            return results;
        }
    }
}