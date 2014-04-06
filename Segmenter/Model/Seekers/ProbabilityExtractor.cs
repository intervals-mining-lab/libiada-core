namespace Segmenter.Model.Seekers
{
    using System;
    using System.Collections.Generic;

    using Segmenter.Base;
    using Segmenter.Base.Collectors;
    using Segmenter.Base.Iterators;
    using Segmenter.Base.Sequences;
    using Segmenter.Model.Criterion;

    /// <summary>
    /// Finds hits of word and calculates its characteristics to select the most perfect occurrence
    /// </summary>
    public class ProbabilityExtractor : SubwordExtractor
    {
        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="par">
        /// The par.
        /// </param>
        /// <returns>
        /// The <see cref="KeyValuePair"/>.
        /// </returns>
        public override sealed KeyValuePair<List<string>, List<int>>? Find(ContentValues par)
        {
            var convoluted = (ComplexChain)par.Get(Enum.GetName(typeof(Formalism), Formalism.Sequence));
            double pbalance = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Balance)) / 100.0;
            int windowLen = (int)par.Get(Enum.GetName(typeof(Parameter), Parameter.Window));
            var alphabet = (FrequencyDictionary)par.Get(Enum.GetName(typeof(Formalism), Formalism.Alphabet));
            var level = (double)par.Get(Enum.GetName(typeof(Parameter), Parameter.CurrentThreshold));
            int scanStep = 1;
            int disp = 0;
            int length = convoluted.Length;

            this.fullEntry = new DataCollector();
            this.minusOneEntry = new DataCollector();
            this.minusTwoEntry = new DataCollector();

            var it = new StartIterator(convoluted, windowLen, scanStep);
            CriterionMethod criteriaCalculator = new ConvolutedCriterionMethod();

            while (it.HasNext())
            {
                it.Next();
                this.fullEntry.Add(it, disp);
                this.FindLess(it);
            }

            this.CalculateStd(convoluted, pbalance, windowLen, length, criteriaCalculator);

            return this.DiscardCompositeWords(alphabet, level);
        }

        /// <summary>
        /// The calculate std.
        /// </summary>
        /// <param name="convoluted">
        /// The convoluted.
        /// </param>
        /// <param name="pbalance">
        /// The pbalance.
        /// </param>
        /// <param name="windowLen">
        /// The window len.
        /// </param>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <param name="criteriaCalculator">
        /// The criteria calculator.
        /// </param>
        public void CalculateStd(
            ComplexChain convoluted,
            double pbalance,
            int windowLen,
            int length,
            CriterionMethod criteriaCalculator)
        {
            foreach (KeyValuePair<List<string>, List<int>> accord in this.fullEntry.Entry())
            {
                PositionFilter.Filtrate(accord.Value, windowLen);
                double frequency = criteriaCalculator.Frequency(accord.Value, length, windowLen);
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