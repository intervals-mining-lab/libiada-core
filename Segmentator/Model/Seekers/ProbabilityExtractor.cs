namespace Segmentator.Model.Seekers
{
    using System;
    using System.Collections.Generic;

    using Segmentator.Base;
    using Segmentator.Base.Collectors;
    using Segmentator.Base.Iterators;
    using Segmentator.Base.Sequencies;
    using Segmentator.Model.Criterion;

    /// <summary>
    /// Finds hits of word and calculates its characteristics to select the most perfect occurence
    /// </summary>
    public class ProbabilityExtractor : SubwordExtractor
    {
        public override sealed KeyValuePair<List<string>, List<int>>? Find(ContentValues par)
        {
            ComplexChain convoluted = (ComplexChain)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Sequence));
            double pbalance = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Balance)) / 100.0;
            int windowLen = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Window));
            FrequencyDictionary alphabet =
                (FrequencyDictionary)par.Get(Formalism.GetName(typeof(Formalism), Formalism.Alphabet));
            double level = (double)par.Get(Enum.GetName(typeof(Parameter), Parameter.CurrentThreshold));
            int scanStep = 1;
            int disp = 0;
            int length = convoluted.Length;

            CriterionMethod criteriaCalculator;

            this.fullEntry = new DataCollector();
            this.minusOneEntry = new DataCollector();
            this.minusTwoEntry = new DataCollector();

            StartIterator it = new StartIterator(convoluted, windowLen, scanStep);
            criteriaCalculator = new ConvolutedCriterionMethod();

            while (it.HasNext())
            {
                it.Next();
                this.fullEntry.Add(it, disp);
                this.FindLess(it);
            }

            this.CalcStd(convoluted, pbalance, windowLen, length, criteriaCalculator);

            return this.DiscardCompositeWords(alphabet, level);
        }

        public void CalcStd(
            ComplexChain convoluted,
            double pbalance,
            int windowLen,
            int length,
            CriterionMethod criteriaCalculator)
        {
            foreach (KeyValuePair<List<string>, List<int>> accord in this.fullEntry.Entry())
            {
                PositionFilter.Filtrate(accord.Value, windowLen);
                double frequency = criteriaCalculator.Frequncy(accord.Value, length, windowLen);
                double design = criteriaCalculator.DesignExpected(
                    accord.Key,
                    length,
                    windowLen,
                    this.minusOneEntry,
                    this.minusTwoEntry);
                double interval = criteriaCalculator.IntervalEstimate(
                    accord.Value,
                    length,
                    windowLen,
                    convoluted.Anchor);
                double std = Math.Abs(pbalance * interval + (1 - pbalance) * frequency - design) / Math.Sqrt(design);
                if (!this.wordPriority.ContainsKey(std))
                {
                    this.wordPriority.Add(std, accord);
                }
            }
        }
    }
}