using System;
using System.Collections.Generic;
using Segmentator.Classes.Base;
using Segmentator.Classes.Base.Collectors;
using Segmentator.Classes.Base.Iterators;
using Segmentator.Classes.Base.Sequencies;
using Segmentator.Classes.Model.Criterion;

namespace Segmentator.Classes.Model.Seekers
{
    /// <summary>
    /// Finds hits of word and calculates its characteristics to select the most perfect occurence
    /// </summary>
    public class ProbabilityExtractor : SubwordExtractor
    {
        public override sealed KeyValuePair<List<string>, List<int>>? Find(ContentValues par)
        {
            ComplexChain convoluted = ((ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Sequence)));
            double pbalance = (int) par.Get(Enum.GetName(typeof (Parameter), Parameter.Balance))/100.0;
            int windowLen = (int) par.Get(Enum.GetName(typeof (Parameter), Parameter.Window));
            FrequencyDictionary alphabet = (FrequencyDictionary) par.Get(Formalism.GetName(typeof (Formalism), Formalism.Alphabet));
            double level = (Double) par.Get(Enum.GetName(typeof (Parameter), Parameter.CurrentThreshold));
            int scanStep = 1;
            int disp = 0;
            int length = convoluted.Length;

            CriterionMethod criteriaCalculator;

            FullEntry = new DataCollector();
            MinusOneEntry = new DataCollector();
            MinusTwoEntry = new DataCollector();

            StartIterator it = new StartIterator(convoluted, windowLen, scanStep);
            criteriaCalculator = new ConvolutedCriterionMethod();

            while (it.HasNext())
            {
                it.Next();
                FullEntry.Add(it, disp);
                FindLess(it);
            }
            CalcStd(convoluted, pbalance, windowLen, length, criteriaCalculator);

            return DiscardCompositeWords(alphabet, level);
        }

        public void CalcStd(ComplexChain convoluted, double pbalance, int windowLen, int length,
                            CriterionMethod criteriaCalculator)
        {
            //new PositionFilter();
            foreach (KeyValuePair<List<String>, List<int>> accord in FullEntry.Entry())
            {
                PositionFilter.Filtrate(accord.Value, windowLen);
                double frequency = criteriaCalculator.Frequncy(accord.Value, length, windowLen);
                double design = criteriaCalculator.DesignExpected(accord.Key, length, windowLen, MinusOneEntry,
                                                                  MinusTwoEntry);
                double interval = criteriaCalculator.IntervalEstimate(accord.Value, length, windowLen,
                                                                      convoluted.Anchor);
                double std = (Math.Abs(pbalance*interval + (1 - pbalance)*frequency - design))/Math.Sqrt(design);
                if (!WordPriority.ContainsKey(std)) WordPriority.Add(std, accord);
            }
        }
    }
}