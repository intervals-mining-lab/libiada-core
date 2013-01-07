using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Iterators;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Criterion;

namespace Segmentation.Classes.Model.Seekers
{
    /// <summary>
    /// Finds hits of word and calculates its characteristics to select the most perfect occurence
    /// 
    /// </summary>
    public class ProbabilityExtractor : SubwordExtractor
    {
        public override sealed KeyValuePair<List<string>, List<int>>? find(ContentValues par)
        {
            ComplexChain convoluted = ((ComplexChain)par.get(Formalism.GetName(typeof(Formalism), Formalism.SEQUENCE)));
            double pbalance = (int) par.get(Enum.GetName(typeof (Parameter), Parameter.BALANCE))/100.0;
            int windowLen = (int) par.get(Enum.GetName(typeof (Parameter), Parameter.WINDOW));
            FrequencyDictionary alphabet = (FrequencyDictionary) par.get(Formalism.GetName(typeof (Formalism), Formalism.ALPHABET));
            double level = (Double) par.get(Enum.GetName(typeof (Parameter), Parameter.CURRENT_THRESHOLD));
            int scanStep = 1;
            int disp = 0;
            int length = convoluted.Length;

            StartIterator it;
            CriterionMethod criteriaCalculator = null;

            this.fullEntry = new DataCollector();
            this.minusOneEntry = new DataCollector();
            this.minusTwoEntry = new DataCollector();

            it = new StartIterator(convoluted, windowLen, scanStep);
            criteriaCalculator = new ConvolutedCriterionMethod();

            while (it.hasNext())
            {
                it.next();
                fullEntry.add(it, disp);
                findLess(it);
            }
            calcStd(convoluted, pbalance, windowLen, length, criteriaCalculator);

            return discardCompositeWords(alphabet, level);
        }

        public void calcStd(ComplexChain convoluted, double pbalance, int windowLen, int length,
                            CriterionMethod criteriaCalculator)
        {
            PositionFilter filter = new PositionFilter();
            foreach (KeyValuePair<List<String>, List<int>> accord in fullEntry.entry())
            {
                filter.filtrate(accord.Value, windowLen);
                double frequency = criteriaCalculator.frequncy(accord.Value, length, windowLen);
                double design = criteriaCalculator.designExpected(accord.Key, length, windowLen, minusOneEntry,
                                                                  minusTwoEntry);
                double interval = criteriaCalculator.intervalEstimate(accord.Value, length, windowLen,
                                                                      convoluted.GetAnchor());
                double std = (Math.Abs(pbalance*interval + (1 - pbalance)*frequency - design))/Math.Sqrt(design);
                if (!wordPriority.ContainsKey(std)) wordPriority.Add(std, accord);
            }
        }
    }
}