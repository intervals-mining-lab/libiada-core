using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
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
            threshold = ThresholdFactory.make(parameters.getThresholdMethod(), parameters);
            criterion = CriterionFactory.make(parameters.getStopCriterion(), threshold, parameters);
            extractor = WordExtractorFactory.getSeeker(parameters.getSeeker());
            balance = parameters.getBalance();
            windowLen = parameters.getWindowlength();
            windowDec = parameters.getWindowdec();
        }

        public void slot()
        {
            SimpleChainSplitter chainConvolutor = null;
            ContentValues par = new ContentValues();
            par.put(Formalism.SEQUENCE, chain = new ComplexChain(inputs[0].getChain(), inputs[0].getChainName()));
            par.put(Formalism.ALPHABET, alphabet = new FrequencyDictionary(chain));

            while (criterion.state(chain, alphabet))
            {
                updateParams(par, threshold.next(criterion));
                chainConvolutor = new SimpleChainSplitter(extractor);
                chain = chainConvolutor.cut(par);
                alphabet = chainConvolutor.getFrequencyDictionary();
            }
            //chain.updateUniforms();
        }

        private void updateParams(ContentValues par, double nextThreshold)
        {
            par.put(Formalism.SEQUENCE, chain = new ComplexChain(inputs[0].getChain(), inputs[0].getChainName()));
            //chain.SetName(inputs[0].getChainName());
            par.put(Parameter.BALANCE, balance);
            par.put(Parameter.WINDOW, windowLen);
            par.put(Parameter.WINDOW_DECREMENT, windowDec);
            par.put(Parameter.CURRENT_THRESHOLD, nextThreshold);
        }

        public List<MainOutputData> upload()
        {
            //BuilderResultData builderResultData = new BuilderResultData(chain, alphabet);
            //MainOutputData resultUpdate = builderResultData.create();
            //resultUpdate.addInfo(criterion, criterion.getValue());
            //resultUpdate.addInfo(threshold, threshold.getValue());
            //ResultDataCreator.saveToFile(resultUpdate);

            //results.add(resultUpdate);
            return results;
        }

        public String getName()
        {
            return Formalism.GetName(typeof (Formalism), formalismType);
        }
    }
}