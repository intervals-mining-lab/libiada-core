﻿using System;
using System.Collections.Generic;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Iterators;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Criterion;

namespace Segmentation.Classes.Model.Seekers
{
    /// <summary>
    /// Finds hits of word and calculates its characteristics to select the most perfect occurence
    /// </summary>
    public class ProbabilityExtractor : SubwordExtractor
    {
        public override sealed KeyValuePair<List<string>, List<int>>? Find(ContentValues par)
        {
            ComplexChain convoluted = ((ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.SEQUENCE)));
            double pbalance = (int) par.Get(Enum.GetName(typeof (Parameter), Parameter.BALANCE))/100.0;
            int windowLen = (int) par.Get(Enum.GetName(typeof (Parameter), Parameter.WINDOW));
            FrequencyDictionary alphabet = (FrequencyDictionary) par.Get(Formalism.GetName(typeof (Formalism), Formalism.ALPHABET));
            double level = (Double) par.Get(Enum.GetName(typeof (Parameter), Parameter.CURRENT_THRESHOLD));
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

            while (it.HasNext())
            {
                it.Next();
                fullEntry.Add(it, disp);
                FindLess(it);
            }
            CalcStd(convoluted, pbalance, windowLen, length, criteriaCalculator);

            return DiscardCompositeWords(alphabet, level);
        }

        public void CalcStd(ComplexChain convoluted, double pbalance, int windowLen, int length,
                            CriterionMethod criteriaCalculator)
        {
            PositionFilter filter = new PositionFilter();
            foreach (KeyValuePair<List<String>, List<int>> accord in fullEntry.Entry())
            {
                filter.filtrate(accord.Value, windowLen);
                double frequency = criteriaCalculator.Frequncy(accord.Value, length, windowLen);
                double design = criteriaCalculator.DesignExpected(accord.Key, length, windowLen, minusOneEntry,
                                                                  minusTwoEntry);
                double interval = criteriaCalculator.IntervalEstimate(accord.Value, length, windowLen,
                                                                      convoluted.Anchor);
                double std = (Math.Abs(pbalance*interval + (1 - pbalance)*frequency - design))/Math.Sqrt(design);
                if (!wordPriority.ContainsKey(std)) wordPriority.Add(std, accord);
            }
        }
    }
}