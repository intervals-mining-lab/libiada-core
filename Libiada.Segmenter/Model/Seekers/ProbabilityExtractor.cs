﻿namespace Libiada.Segmenter.Model.Seekers;

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
    /// The <see cref="KeyValuePair{List{string},List{int}}?"/>.
    /// </returns>
    public override sealed KeyValuePair<List<string>, List<int>>? Find(Dictionary<string, object> par)
    {
        // TODO: refactor it to rerturn tuple
        ComplexSequence convoluted = (ComplexSequence)par["Sequence"];
        double pbalance = (int)par["Balance"] / 100.0;
        int windowLen = (int)par["Window"];
        FrequencyDictionary alphabet = (FrequencyDictionary)par["Alphabet"];
        double level = (double)par["CurrentThreshold"];
        int scanStep = 1;
        int disp = 0;
        int length = convoluted.Length;

        fullEntry = new DataCollector();
        minusOneEntry = new DataCollector();
        minusTwoEntry = new DataCollector();

        StartIterator it = new(convoluted, windowLen, scanStep);
        CriterionMethod criteriaCalculator = new ConvolutedCriterionMethod();

        while (it.HasNext())
        {
            it.Next();
            fullEntry.Add(it, disp);
            FindLess(it);
        }

        CalculateStd(convoluted, pbalance, windowLen, length, criteriaCalculator);

        return DiscardCompositeWords(alphabet, level);
    }

    /// <summary>
    /// std calculation method.
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
        ComplexSequence convoluted,
        double pbalance,
        int windowLen,
        int length,
        CriterionMethod criteriaCalculator)
    {
        foreach (KeyValuePair<List<string>, List<int>> accord in fullEntry.Entry())
        {
            PositionFilter.Filtrate(accord.Value, windowLen);
            double frequency = criteriaCalculator.Frequency(accord.Value, length, windowLen);
            double design = criteriaCalculator.DesignExpected(
                accord.Key,
                length,
                windowLen,
                minusOneEntry,
                minusTwoEntry);
            double interval = criteriaCalculator.IntervalEstimate(
                accord.Value,
                length,
                windowLen,
                convoluted.Anchor);
            double std = Math.Abs((pbalance * interval) + ((1 - pbalance) * frequency) - design) / Math.Sqrt(design);
            if (!wordPriority.ContainsKey(std))
            {
                wordPriority.Add(std, accord);
            }
        }
    }
}
